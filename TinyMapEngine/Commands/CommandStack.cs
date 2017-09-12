using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMapEngine.Commands
{
    public class CommandStack
    {
        private static Stack<Command> UndoStack { get; } = new Stack<Command>();
        private static Stack<Command> RedoStack { get; } = new Stack<Command>();

        public static event EventHandler<ExecuteEventArgs> Executed;
        public static event EventHandler<ExecuteEventArgs> Undone;
        public static event EventHandler<EventArgs> Cleared;

        public static void Execute(Command command, bool clearRedo = true)
        {
            UndoStack.Push(command);
            command.Do();
            if (clearRedo)
                RedoStack.Clear();
            Executed?.Invoke(null, new ExecuteEventArgs(command));
        }

        public static Command Undo()
        {
            Command c = UndoStack.Pop();
            c.Undo();
            RedoStack.Push(c);
            Undone?.Invoke(null, new ExecuteEventArgs(c, true));
            return c;
        }

        public static void Redo()
        {
            Command c = RedoStack.Pop();
            Execute(c, false);
        }

        public static void Clear()
        {
            UndoStack.Clear();
            RedoStack.Clear();
            Cleared?.Invoke(null, new EventArgs());
        }

        public static bool CanRedo()
        {
            return RedoStack.Count > 0;
        }

        public static bool CanUndo()
        {
            return UndoStack.Count > 0;
        }

        public class ExecuteEventArgs : EventArgs
        {
            public Command Command { get; }
            public bool Undo { get; }

            public ExecuteEventArgs(Command command, bool undo = false) : base()
            {
                Command = command;
                Undo = undo;
            }
        }
    }
}
