
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StatePattern
{
    abstract class State
    {
        protected abstract void ChangeState(Father father, Mark Mark);

        internal virtual void HandleMark(Father father,Mark mark)
        {
            ChangeState(father,mark);
        }

        
    }

    class NeuteralState : State
    {
        internal NeuteralState()
        {
            Console.WriteLine("Отец находится в нейтральном состоянии:");
            Hope();

        }
        protected override void ChangeState(Father father, Mark Mark)
        {
            switch (Mark)
            {
                case Mark.Bad: father.State = new PityState();
                    break;
                case Mark.Good: father.State = new JoyState();
                    break;
                
            }

        }
        private void Hope()
        {
            Console.WriteLine("Надеится на хорошие оценки.");
        }
    }
    class PityState : State
    {
        internal PityState()
        {
            Console.WriteLine("Отец находится в состоянии жалости: ");
            Calm();
        }

        private void Calm()
        {
            Console.WriteLine("Отец успокаивает за неудачу.");
        }

        protected override void ChangeState(Father father, Mark Mark)
        {
            switch (Mark)
            {
                case Mark.Bad:
                    father.State = new AngryState();
                    break;
                case Mark.Good:
                    father.State = new NeuteralState();
                    break;
            }
        }
    }
    class JoyState : State
    {
        public JoyState()
        {
            Console.WriteLine("Отец находится в состоянии радости: ");
            Joy();
        }

        private void Joy()
        {
            Console.WriteLine("Отец хвалит сына.");
        }

        protected override void ChangeState(Father father, Mark Mark)
        {
            switch (Mark)
            {
                case Mark.Bad:
                    father.State = new PityState();
                    break;
                case Mark.Good:
                    father.State = new StrongJoyState();
                    break;
                default:
                    break;
            }
        }
    }
    class StrongJoyState : State
    {
        public StrongJoyState()
        {
            Console.WriteLine("Отец находится в состоянии чрезмерной радости.");
            Exult();
        }

        private void Exult()
        {
            Console.WriteLine("Отец прыгает от счастья и поощряет сына.");
        }

        protected override void ChangeState(Father father, Mark Mark)
        {
            switch (Mark)
            {
                case Mark.Bad:
                    father.State = new PityState();
                    break;
                case Mark.Good:
                    father.State = new StrongJoyState();
                    break;
                default:
                    break;
            }
        }
    }
    class AngryState : State
    {
        public AngryState()
        {
            Console.WriteLine("Отец в состоянии злости: ");
            Scold();
        }

        private void Scold()
        {
            Console.WriteLine("Отец ругает сына.");
        }

        protected override void ChangeState(Father father, Mark Mark)
        {
            switch (Mark)
            {
                case Mark.Bad:
                    father.State = new StrongAngryState();
                    break;
                case Mark.Good:
                    father.State = new NeuteralState();
                    break;
                default:
                    break;
            }
        }
    }
    class StrongAngryState : State
    {
        public StrongAngryState()
        {
            Console.WriteLine("Отец в состоянии бешенства:");
            BeatBelt();
        }

        private void BeatBelt()
        {
            Console.WriteLine("Отец пустил в ход ремень.");
        }

        protected override void ChangeState(Father father, Mark Mark)
        {
            switch (Mark)
            {
                case Mark.Bad:
                    father.State = new StrongAngryState();

                    break;
                case Mark.Good:
                    father.State = new NeuteralState();
                    break;
                default:
                    break;
            }
        }
    }
}

