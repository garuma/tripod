// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace GLib {

	using System;

#region Autogenerated code
	public interface Icon : GLib.IWrapper {

		bool Equal(GLib.Icon icon2);
	}

	[GLib.GInterface (typeof (IconAdapter))]
	public interface IconImplementor : GLib.IWrapper {

		uint Hash ();
		bool Equal (GLib.Icon icon2);
	}
#endregion
}