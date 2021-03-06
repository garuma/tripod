//
// Client.cs
//
// Author:
//   Ruben Vermeersch <ruben@savanne.be>
//
// Copyright (C) 2010 Ruben Vermeersch
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using Gtk;
using Hyena;
using Hyena.Data.Sqlite;
using Tripod.Base;
using Tripod.Model;
using System.Linq;
using FlashUnit.Gui;

namespace FlashUnit
{
    public class Client
    {
        public static void Main (string[] args)
        {
            Core.Initialize ("FlashUnit", ref args);
            
            Log.Information ("Hello World! Flash!");

            var main_window = new MainWindow ();
            main_window.Destroyed += (o, e) => Application.Quit ();
            main_window.Show ();

            /*if (ApplicationContext.CommandLine ["add-foldersrc"] != String.Empty) {
                var source = new LocalFolderPhotoSource (new Uri (ApplicationContext.CommandLine["add-foldersrc"]));
                Core.MainCachePhotoSource.RegisterPhotoSource (source);
            }*/

            /*var enu = (Core.MainCachePhotoSource.Photos as TripodQuery<Tripod.Sources.Cache.CachePhoto>).Where (p => p.Comment != String.Empty);
            foreach (IPhoto photo in enu.Take (25)) {
                Log.Debug (photo.Uri.ToString ());
            }

            var model = new HyenaLINQModel<Tripod.Sources.Cache.CachePhoto> (enu);
            model.Reload ();
            Hyena.Log.Debug (model == null ? "null" : model.ToString ());
            Hyena.Log.Debug (model.Count.ToString ());*/

            Application.Run ();
        }
    }
}
