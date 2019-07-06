using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Command_2.Model;

namespace Wpf_Command_2
{
    class MainWindowViewModel : ObservableObject
    {
        private ToDoRepository db = new ToDoRepository();
        
        private ObservableCollection<ToDoItem> items;
        public ObservableCollection<ToDoItem> Items { get => items; set => Set(ref items, value); }

        private ToDoItem selectedTask;
        public ToDoItem SelectedTask { get => selectedTask; set => Set(ref selectedTask, value); }

        private string taskName;
        public string TaskName { get => taskName; set => Set(ref taskName, value); }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(db.List());
        }

        private RelayCommand addTaskCommnad;
        public RelayCommand AddTaskCommand
        {
            get => addTaskCommnad ?? (addTaskCommnad = new RelayCommand(
              param =>
              {
                  //Items.Add(new ToDoItem { Name = TaskName, IsDone = false });
                  db.Add(new ToDoItem { Name = TaskName, IsDone = false });
                  Items = new ObservableCollection<ToDoItem>(db.List());
                  TaskName = "";
              },
              param => !String.IsNullOrWhiteSpace(TaskName)
              ));
        }

        private RelayCommand doneCommand;
        public RelayCommand DoneCommand
        {
            get => doneCommand ?? (doneCommand = new RelayCommand(
              param =>
              {
                  var task = param as ToDoItem;
                  db.Edit(task.Id);
                  Items = new ObservableCollection<ToDoItem>(db.List());
                  //task.IsDone = !task.IsDone ;
              },
              param => SelectedTask != null
              ));
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get => removeCommand ?? (removeCommand = new RelayCommand(
              param =>
              {
                  db.Remove(SelectedTask.Id);
                  Items = new ObservableCollection<ToDoItem>(db.List());
                  //task.IsDone = !task.IsDone ;
              },
              param => SelectedTask != null
              ));
        }
    }
}
