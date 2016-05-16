using System;
using Xamarin.Forms;

namespace SampleApp
{
	class MyDataTemplateSelector : DataTemplateSelector
	{
		public MyDataTemplateSelector()
		{
			// Retain instances!
			this.ExecutionDataTemplate = new DataTemplate(typeof(ViewCellExecution));
			this.BreakDataTemplate = new DataTemplate(typeof(ViewCellBreak));
			this.DepotDataTemplate = new DataTemplate(typeof(ViewCellDepot));
			this.ArrivalDataTemplate = new DataTemplate(typeof(ViewCellArrival));
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var messageVm = item as StepViewModel;
			if (messageVm == null)
				return null;
			if (messageVm.StepType.CompareTo ("departure") == 0 || messageVm.StepType.CompareTo ("arrival") == 0)
				return this.DepotDataTemplate;
			else if (messageVm.StepType.CompareTo ("break") == 0)
				return this.BreakDataTemplate;
			else
				return this.ExecutionDataTemplate;
			
		}

		private readonly DataTemplate ExecutionDataTemplate;
		private readonly DataTemplate BreakDataTemplate;
		private readonly DataTemplate DepotDataTemplate;
		private readonly DataTemplate ArrivalDataTemplate;
	}
}

