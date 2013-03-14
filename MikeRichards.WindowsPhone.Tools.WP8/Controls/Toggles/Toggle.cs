using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.Toggles
{
	public abstract partial class Toggle : UserControl
	{
		public delegate void ToggleChangeEvent(object sender, ToggleChangeEventArgs args);
		public event ToggleChangeEvent Changing;
		public event ToggleChangeEvent Changed;

		private ToggleDirection? _initialDirection;
		[Description("The initial state of the toggle: Left or Right"), Category("Data")]
		public ToggleDirection InitialDirection
		{
			get { return _initialDirection ?? ToggleDirection.Left; }
			set
			{
				if (!_initialDirection.HasValue)
				{
					_initialDirection = value;
					ToggleSwitchElement.SetValue(Canvas.LeftProperty, value == ToggleDirection.Left ? 1.0 : 43.0);
				}
			}
		}

		[Description("A custom identifier for this toggle control. You can set it to whatever you need."), Category("Data")]
		public string Id { get; set; }

		protected abstract UIElement ToggleSwitchElement { get; }

		private ToggleDirection? _direction;
		public ToggleDirection Direction
		{
			get { return _direction ?? (_direction = InitialDirection).Value; }
			private set { _direction = value; }
		}

		public void ToggleSwitch(bool doFireChangeEvents = true)
		{
			SetToggle(Direction.Opposite(), doFireChangeEvents);
		}

		public void ToggleLeft(bool doFireChangeEvents = true)
		{
			SetToggle(ToggleDirection.Left, doFireChangeEvents);
		}

		public void ToggleRight(bool doFireChangeEvents = true)
		{
			SetToggle(ToggleDirection.Right, doFireChangeEvents);
		}

		public void SetToggle(ToggleDirection direction, bool doFireChangeEvents = true)
		{
			if (direction == Direction) return;

			Direction = direction;

			if (doFireChangeEvents && Changing != null)
			{
				Changing(this, new ToggleChangeEventArgs(Direction));
			}

			double newCanvasLeftSettingForToggleSwitchElement = Direction == ToggleDirection.Left ? 1.0 : 43.0;

			Dispatcher.BeginInvoke(() =>
			{
				var storyboard = new Storyboard();
				var animationForSwitchEllipse = new DoubleAnimation
				{
					From = Canvas.GetLeft(ToggleSwitchElement),
					To = newCanvasLeftSettingForToggleSwitchElement,
					Duration = TimeSpan.FromMilliseconds(125.0)
				};

				Storyboard.SetTarget(animationForSwitchEllipse, ToggleSwitchElement);
				Storyboard.SetTargetProperty(animationForSwitchEllipse, new PropertyPath(Canvas.LeftProperty));

				if (doFireChangeEvents && Changed != null)
				{
					storyboard.Completed += (sender, args) =>
					{
						if (Direction == direction)
						{
							new Thread(() => Changed(this, new ToggleChangeEventArgs(direction))).Start();
						}
					};
				}

				storyboard.Children.Add(animationForSwitchEllipse);
				storyboard.Begin();
			});				
		}
	}

	public class ToggleChangeEventArgs : EventArgs
	{
		public ToggleDirection Direction { get; private set; }

		public ToggleChangeEventArgs(ToggleDirection direction)
		{
			Direction = direction;
		}
	}
}
