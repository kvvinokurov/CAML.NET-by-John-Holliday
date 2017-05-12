#region Copyright(c) John F. Holliday, All Rights Reserved.

// -----------------------------------------------------------------------------
// Copyright(c) 2007 John F. Holliday, All Rights Reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
//   1.  Redistribution of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//   2.  Redistribution in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//   3.  The name of the author may not be used to endorse or promote products
//       derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
// EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
// OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
// OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// -----------------------------------------------------------------------------

#endregion
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.SharePoint;

namespace JohnHolliday.Caml.Net
{
    /// <summary>
    /// Used to indicate fields which are mapped to SharePoint site columns.
    /// </summary>
    public interface ICamlField
    {
        /// <summary>
        /// Specifies the target site column name.
        /// </summary>
        String FieldName { get; }
        /// <summary>
        /// Updates the value of the associated field.
        /// </summary>
        /// <param name="target">the object containing the field to be set</param>
        /// <param name="listItem">the list item containing the field value</param>
        /// <param name="fieldInfo">the field metadata</param>
        /// <returns></returns>
        bool SetValue(object target, SPListItem listItem, FieldInfo fieldInfo);
    }
}
