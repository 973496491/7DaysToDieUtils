using Sunny.UI;

namespace _7DaysToDieUtils.View
{
    public partial class HelperItemForm : UIForm
    {
        public HelperItemForm()
        {
            InitializeComponent();
        }

        private void Zombie_Btn_Click(object sender, System.EventArgs e)
        {
            var form = new ZombieListForm();
            form.ShowDialog();
            Close();
        }

        private void Prop_Btn_Click(object sender, System.EventArgs e)
        {
            var form = new PropListForm();
            form.ShowDialog();
            Close();
        }
    }
}
