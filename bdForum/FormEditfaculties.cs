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
    public partial class FormEditfaculties : Form
    {
        [Dependency] 
        public new IUnityContainer Container { get; set; }
        public string Name
        {
            set { name = value; }
        }
        private readonly subjectLogic logic;
        private string name;
        public FormEditfaculties(subjectLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormEditTopic_Load(object sender, EventArgs e)
        {
            if (!name.Equals(null))
            {
                try
                {
                    var view = logic.Read(new subjectBindingModel { Name = name })?[0];
                    if (view != null)
                    {
                        textBox1.Text = view.Name;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                logic.CreateOrUpdate(new subjectBindingModel { Name = textBox1.Text });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }
    }
}
