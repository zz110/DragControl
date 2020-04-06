   public class DragControl : Component
    {
        private Control handleControl;

        private bool IsMouseDown = false;
        private Point startPoint;

        public Control SelectControl
        {
            get
            {
                return this.handleControl;
            }
            set
            {
                this.handleControl = value;
                this.handleControl.MouseDown += HandleControl_MouseDown;
                this.handleControl.MouseUp += HandleControl_MouseUp;
                this.handleControl.MouseMove += HandleControl_MouseMove;
            }
        }

        private void HandleControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Point endPoint = e.Location;
                int x = endPoint.X - startPoint.X;
                int y = endPoint.Y - startPoint.Y;
                this.handleControl.Location = new Point(
                    this.handleControl.Location.X + x,
                    this.handleControl.Location.Y + y);
            }
        }

        private void HandleControl_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void HandleControl_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            startPoint = e.Location;
        }
    }
