using System;
using System.Windows.Forms;
using qf4net;

namespace Samples.Library
{
	/// <summary>
	/// IHsmExecutionModel.
	/// </summary>
	public interface IHsmExecutionModel
	{
	    BookFrame CreateHsm (string id, string storageFileName);
	}
}
