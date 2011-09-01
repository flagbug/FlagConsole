using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlagConsole.Util;
using FlagConsole.Drawing;

namespace FlagConsole.Controls
{
    public abstract class Control
    {
        #region Members
        private bool activated = false;
        /// <summary>
        /// Gets or protected sets the activated status
        /// </summary>
        public bool Activated
        {
            get
            {
                return this.activated;
            }

            
            protected set
            {
                this.activated = value;
            }
        }

        private Size size = new Size();
        /// <summary>
        /// Size of the control
        /// </summary>
        public Size Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        private Position position = new Position();
        /// <summary>
        /// Postion where the control should be displayed (absolute to the screen)
        /// </summary>
        public virtual Position AbsolutePosition
        {
            get
            {
                return this.position + this.parentContainer.AbsolutePosition;
            }

            set
            {
                this.position = value;
            }
        }

        /// <summary>
        /// Relative position to the parent container
        /// </summary>
        public Position RelativePosition
        {
            get
            {
                return this.position;
            }
        }

        private Container parentContainer;
        /// <summary>
        /// The parent container
        /// </summary>
        public Container ParentContainer
        {
            get
            {
                return this.parentContainer;
            }

            set
            {
                this.parentContainer = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Actitvates and shows the control, if the parent container is activated
        /// </summary>
        public virtual void Activate()
        {
            if (ParentContainer.Activated)
            {
                this.Activated = true;
                this.Show();
            }
        }

        /// <summary>
        /// Deactivates and clears the control
        /// </summary>
        public virtual void Deactivate()
        {
            this.Activated = false;
            this.ClearControl();
        }

        /// <summary>
        /// Shows the control in the console
        /// </summary>
        protected abstract void Show();
        
        /// <summary>
        /// Clears the area where the control is drawn
        /// </summary>
        protected virtual void ClearControl()
        {
            Rectangle eraseArea = new Rectangle(this.AbsolutePosition, this.Size, ' ', true);
            eraseArea.Draw();
        }

        /// <summary>
        /// Updates the control
        /// </summary>
        public virtual void Update()
        {
            this.ClearControl();
            this.Show();
        }
        #endregion
    }
}
