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
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;

namespace JohnHolliday.Caml.Net
{
    /// <summary>
    /// This attribute is used to declare an explicit mapping
    /// between a column in a SharePoint list and a data member
    /// of a custom class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class CamlField : Attribute, ICamlField
    {
        string m_fieldName = string.Empty;

        /// <summary>
        /// Constructor that accepts the SharePoint field name to which
        /// the member is to be mapped.
        /// </summary>
        /// <param name="fieldName"></param>
        public CamlField(string fieldName)
        {
            m_fieldName = fieldName;
        }

        #region ICamlField Members

        /// <summary>
        /// 
        /// </summary>
        public String FieldName
        {
            get
            {
                return m_fieldName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="listItem"></param>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        public bool SetValue(object target, SPListItem listItem, FieldInfo fieldInfo)
        {
            bool result = false;
            try
            {
                fieldInfo.SetValue(target, listItem[FieldName]);
                result = true;
            }
            catch
            {
            }
            return result;
        }

        #endregion
    }
}
