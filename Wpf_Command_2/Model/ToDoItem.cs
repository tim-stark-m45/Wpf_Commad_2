using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Command_2.Model
{
    public class ToDoItem : ObservableObject
    {
        private int id;
        public int Id { get => id; set => Set(ref id, value); }

        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private bool isDone;
        public bool IsDone { get => isDone; set => Set(ref isDone, value); }

    }
}
