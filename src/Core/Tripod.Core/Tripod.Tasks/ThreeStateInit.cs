// ThreeStateInit.cs
//
// Copyright (c) 2010 Jérémie "Garuma" Laval
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
//
//

using System.Threading;

namespace Tripod.Tasks
{
	public struct ThreeStateInit
	{
		int current;

		const int Uninitialized = 0;
		const int Initializing = 1;
		const int Initialized = 2;

		public bool IsInitialized {
			get {
				return current == Initialized;
			}
		}

		public bool ProposeToInitialize ()
		{
			return Interlocked.CompareExchange (ref current, Initializing, Uninitialized) == Uninitialized;
		}

		public void SetInitialized ()
		{
			current = Initialized;
		}

		public void WaitForInitialization ()
		{
			SpinWait sw = new SpinWait ();
			
			while (current != Initialized)
				sw.SpinOnce ();
		}
	}
}