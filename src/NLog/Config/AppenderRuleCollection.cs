//
// Copyright (c) 2004 Jaroslaw Kowalski <jaak@polbox.com>
//
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
//
// * Redistributions of source code must retain the above copyright notice,
//   this list of conditions and the following disclaimer.
//
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution.
//
// * Neither the name of the Jaroslaw Kowalski nor the names of its
//   contributors may be used to endorse or promote products derived from this
//   software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
// THE POSSIBILITY OF SUCH DAMAGE.
//

using System;
using System.Collections;
using System.Collections.Specialized;

using NLog;
using NLog.Appenders;
using NLog.Filters;

namespace NLog.Config {
    /// <summary>
    /// A collection of elements of type AppenderRule
    /// </summary>
    public class AppenderRuleCollection: System.Collections.CollectionBase {
        /// <summary>
        /// Initializes a new empty instance of the AppenderRuleCollection class.
        /// </summary>
        public AppenderRuleCollection() {
            // empty
        }

        /// <summary>
        /// Initializes a new instance of the AppenderRuleCollection class, containing elements
        /// copied from an array.
        /// </summary>
        /// <param name="items">
        /// The array whose elements are to be added to the new AppenderRuleCollection.
        /// </param>
        public AppenderRuleCollection(AppenderRule[] items) {
            this.AddRange(items);
        }

        /// <summary>
        /// Initializes a new instance of the AppenderRuleCollection class, containing elements
        /// copied from another instance of AppenderRuleCollection
        /// </summary>
        /// <param name="items">
        /// The AppenderRuleCollection whose elements are to be added to the new AppenderRuleCollection.
        /// </param>
        public AppenderRuleCollection(AppenderRuleCollection items) {
            this.AddRange(items);
        }

        /// <summary>
        /// Adds the elements of an array to the end of this AppenderRuleCollection.
        /// </summary>
        /// <param name="items">
        /// The array whose elements are to be added to the end of this AppenderRuleCollection.
        /// </param>
        public virtual void AddRange(AppenderRule[] items) {
            foreach (AppenderRule item in items) {
                this.List.Add(item);
            }
        }

        /// <summary>
        /// Adds the elements of another AppenderRuleCollection to the end of this AppenderRuleCollection.
        /// </summary>
        /// <param name="items">
        /// The AppenderRuleCollection whose elements are to be added to the end of this AppenderRuleCollection.
        /// </param>
        public virtual void AddRange(AppenderRuleCollection items) {
            foreach (AppenderRule item in items) {
                this.List.Add(item);
            }
        }

        /// <summary>
        /// Adds an instance of type AppenderRule to the end of this AppenderRuleCollection.
        /// </summary>
        /// <param name="value">
        /// The AppenderRule to be added to the end of this AppenderRuleCollection.
        /// </param>
        public virtual void Add(AppenderRule value) {
            this.List.Add(value);
        }

        /// <summary>
        /// Determines whether a specfic AppenderRule value is in this AppenderRuleCollection.
        /// </summary>
        /// <param name="value">
        /// The AppenderRule value to locate in this AppenderRuleCollection.
        /// </param>
        /// <returns>
        /// true if value is found in this AppenderRuleCollection;
        /// false otherwise.
        /// </returns>
        public virtual bool Contains(AppenderRule value) {
            return this.List.Contains(value);
        }

        /// <summary>
        /// Return the zero-based index of the first occurrence of a specific value
        /// in this AppenderRuleCollection
        /// </summary>
        /// <param name="value">
        /// The AppenderRule value to locate in the AppenderRuleCollection.
        /// </param>
        /// <returns>
        /// The zero-based index of the first occurrence of the _ELEMENT value if found;
        /// -1 otherwise.
        /// </returns>
        public virtual int IndexOf(AppenderRule value) {
            return this.List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an element into the AppenderRuleCollection at the specified index
        /// </summary>
        /// <param name="index">
        /// The index at which the AppenderRule is to be inserted.
        /// </param>
        /// <param name="value">
        /// The AppenderRule to insert.
        /// </param>
        public virtual void Insert(int index, AppenderRule value) {
            this.List.Insert(index, value);
        }

        /// <summary>
        /// Gets or sets the AppenderRule at the given index in this AppenderRuleCollection.
        /// </summary>
        public virtual AppenderRule this[int index]
        {
            get {
                return (AppenderRule) this.List[index];
            }
            set {
                this.List[index] = value;
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific AppenderRule from this AppenderRuleCollection.
        /// </summary>
        /// <param name="value">
        /// The AppenderRule value to remove from this AppenderRuleCollection.
        /// </param>
        public virtual void Remove(AppenderRule value) {
            this.List.Remove(value);
        }

        /// <summary>
        /// Type-specific enumeration class, used by AppenderRuleCollection.GetEnumerator.
        /// </summary>
    public class Enumerator: System.Collections.IEnumerator {
            private System.Collections.IEnumerator wrapped;

            public Enumerator(AppenderRuleCollection collection) {
                this.wrapped = ((System.Collections.CollectionBase)collection).GetEnumerator();
            }

            public AppenderRule Current
            {
                get {
                    return (AppenderRule) (this.wrapped.Current);
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get {
                    return (AppenderRule) (this.wrapped.Current);
                }
            }

            public bool MoveNext() {
                return this.wrapped.MoveNext();
            }

            public void Reset() {
                this.wrapped.Reset();
            }
        }

        /// <summary>
        /// Returns an enumerator that can iterate through the elements of this AppenderRuleCollection.
        /// </summary>
        /// <returns>
        /// An object that implements System.Collections.IEnumerator.
        /// </returns>
        public new virtual AppenderRuleCollection.Enumerator GetEnumerator() {
            return new AppenderRuleCollection.Enumerator(this);
        }
    }
}