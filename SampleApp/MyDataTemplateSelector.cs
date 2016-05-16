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
			var stepVM = item as Step;
			if (stepVM == null)
				return this.ExecutionDataTemplate;
			
			if (stepVM.Type.CompareTo ("departure") == 0 || stepVM.Type.CompareTo ("arrival") == 0)
				return this.DepotDataTemplate;
			else if (stepVM.Type.CompareTo ("break") == 0)
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

