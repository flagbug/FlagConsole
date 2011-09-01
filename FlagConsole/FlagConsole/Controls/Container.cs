using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlagConsole.Controls
{
    public abstract class Container : Control
    {
        private List<Control> controls = new List<Control>();

        /// <summary>
        /// Adds a control to the container
        /// </summary>
        /// <param name="control">The control to add</param>
        public void AddControl(Control control)
        {
            this.controls.Add(control);
            control.ParentContainer = this;
        }

        /// <summary>
        /// Removes a control from the container
        /// </summary>
        /// <param name="control">The control to remove</param>
        public void RemoveControl(Control control)
        {
            this.controls.Remove(control);
            control.ParentContainer = null;
        }

        /// <summary>
        /// Activates and shows the container
        /// </summary>
        public override void Activate()
        {
            if (this.ParentContainer == null || this.ParentContainer.Activated)
            {
                this.Activated = true;
                this.Show();

                foreach(Control control in this.controls)
                {
                    if(!control.Activated)
                    {
                        control.Activate();
                    }
                }
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();

            foreach(Control control in this.controls)
            {
                control.Deactivate();
            }
        }

        public override void Update()
        {
            base.Update();

            foreach(Control control in this.controls)
            {
                if(control.Activated)
                {
                    control.Update();
                }
            }
        }
    }
}
