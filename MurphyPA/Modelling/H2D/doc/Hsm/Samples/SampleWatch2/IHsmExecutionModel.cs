using System;
using qf4net;

namespace SampleWatch
{
	/// <summary>
	/// IHsmExecutionModel.
	/// </summary>
	public interface IHsmExecutionModel
	{
	    Samples.SampleWatch CreateHsm (string id);
	}
}
