using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.BusinessLogic;
using Unity;

namespace bdForum
{
    public partial class Formapplicants : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly applicantsLogic logic;
        private readonly subjectLogic topiclogic;
        private readonly universityLogic vlogic;
        private readonly dirictionLogic mlogic;
        public string nameTopic;
        public Formapplicants(applicantsLogic logic, universityLogic vlogic, dirictionLogic mlogic, subjectLogic topiclogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.vlogic = vlogic;
            this.mlogic = mlogic;
            this.topiclogic = topiclogic;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var this_topic = topiclogic.Read(new subjectBindingModel
            {
                Name = nameTopic
            })[0];
            Console.WriteLine(nameTopic);
            topiclogic.CreateOrUpdate(new subjectBindingModel
            {
                Name = nameTopic,
                NumberOfMessages = this_topic.NumberOfMessages + 1,
                NumberOfVisitors = this_topic.NumberOfVisitors
            });
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

                logic.CreateOrUpdate(new applicantsBindingModel {  
                    Text = TextBox1.Text,
                    Time = DateTime.Now,
                    LoginUser = Program.Visitor.LoginUser,
                    NameTopic = nameTopic
                });
                if (Program.Visitor.Status != null)
                {
                    vlogic.CreateOrUpdate(new universityBindingModel
                    {
                        LoginUser = Program.Visitor.LoginUser,
                        Password = Program.Visitor.Password,
                        Decency = Program.Visitor.Decency,
                        Email = Program.Visitor.Email,
                        Status = Program.Visitor.Status,
                        TotalTime = Program.Visitor.TotalTime,
                        CountOfMessages = Program.Visitor.CountOfMessages + 1
                    });
                Program.Visitor.CountOfMessages += 1;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; 
                Close();
            }
           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }
    }
}
