using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Patt
{
    public class MainPresenter
    {
        private readonly IMainForm View;
        private readonly IFileManager Manager;
        private readonly IMessageService messageService;

        public string currentPath;
        public MainPresenter(IMainForm View, IFileManager Manager, IMessageService messageService)
        {
            this.View = View;
            this.Manager = Manager;
            this.messageService = messageService;

            View.SymbolCount = 0.ToString();

            View.ContentChanged += View_ContentChanged;
            View.FileOpenClick += View_FileOpenClick;
            View.FileSaveClick += View_FileSaveClick;
        }

        private void View_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                Manager.SaveContent(View.content,currentPath);
                messageService.ShowMessage("File has been successfully saved");
            }
            catch(Exception exception)
            {

            }
        }

        private void View_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                if(!Manager.IsExist(View.FilePath))
                {
                    messageService.ShowExclamation("Chisen file doesn't exist");
                    return;
                }
                currentPath = View.FilePath;
                View.content = Manager.GetContent(View.FilePath);
                View.SymbolCount = Manager.GetSymbolCount(View.FilePath).ToString();

            }
            catch(Exception exception)
            {
                messageService.ShowError(exception.Message);
            }
        }

        private void View_ContentChanged(object sender, EventArgs e)
        {
            View.SymbolCount = Manager.GetSymbolCount(View.content).ToString();
        }
    }
}
