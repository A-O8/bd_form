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
    public partial class FormListsubject : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int IDMessage
        {
            set { id = value; }
        }
        private readonly facultiesLogic likelogic;
        private int id;
        public FormListsubject(facultiesLogic likelogic)
        {
            InitializeComponent();
            this.likelogic = likelogic;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }

        private void FormListLikes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Program.myTimer = DateTime.Now;
            var listbindmodels = likelogic.Read(new facultiesBindingModel
            {
                IdMessage = id
            });
            var answer = Program.myTimer - DateTime.Now;
            Console.WriteLine("Время выполнения: " + answer);
            foreach (var like in listbindmodels)
            {
                listBoxLikes.Items.Add(like.LoginUser);
            }
        }
    }
}
