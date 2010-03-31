// 
// PhotoGridViewLayout.cs
// 
// Author:
//   Mike Gemuende <mike@gemuende.de>
// 
// Copyright (c) 2010 Mike Gemuende
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

using Tripod.Model;

using Hyena.Data.Gui;

using Tripod.Graphics;
using Hyena.Collections;
using Hyena.Gui;
using Cairo;
using Gdk;

namespace Tripod.Model.Gui
{


    public class PhotoGridViewLayout : DataViewLayoutGrid
    {
        public PhotoGridThumbnailCache ThumbnailCache { get; private set; }
        public IPhotoGridCaptionRenderer CaptionRender { get; private set; }

        public PhotoGridViewLayout ()
        {
            ThumbnailCache = new PhotoGridThumbnailCache (this, 200, 150);
            ChildAllocator = () => new PhotoGridViewChild ();
            CaptionRender = new PhotoGridDateCaptionRender ();
        }

        public void InvalidateThumbnail (IPhoto photo)
        {
            PhotoGridViewChild child = GetDrawingChild (photo);

            if (child != null)
                child.InvalidateThumbnail ();
        }

        protected PhotoGridViewChild GetDrawingChild (IPhoto photo)
        {
            foreach (PhotoGridViewChild child in Children) {
                if (child != null && child.BoundPhoto == photo) {
                    return child;
                }
            }

            return null;
        }
    }
}
