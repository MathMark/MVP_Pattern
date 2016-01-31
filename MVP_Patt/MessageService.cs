using System.Windows.Forms;

namespace MVP_Patt
{
    public interface IMessageService
    {
        void ShowMessage(string Message);
        void ShowExclamation(string Exclamation);
        void ShowError(string Error);
    }

    class MessageService:IMessageService
    {
        public void ShowMessage(string Message)
        {
            MessageBox.Show(Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowExclamation(string Exclamation)
        {
            MessageBox.Show(Exclamation, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string Error)
        {
            MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
