using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube.WpfApp.MVVM
{
    /// <summary>
    /// Модель представление, та которую мы будем отображать в нашем окне
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        // Инициализация модели представления, заполнение наших переменных данными.
        public MainWindowViewModel()
        {
            ProjectList = new List<string>()
            {
                "YouTube", "YouTube.ORM", "YouTube.WpfApp"
            };

            SelectedProject = ProjectList.First();
        }


        private List<string> _ProjectList;

        public List<string> ProjectList {
            get { return _ProjectList; }
            set { _ProjectList = value; NotifyPropertyChanged("ProjectList");
            }
        }

        private string _SelectedProject;

        public string SelectedProject {
            get { return _SelectedProject; }
            set { _SelectedProject = value; NotifyPropertyChanged("SelectedProject");
            }
        }


    }
}
