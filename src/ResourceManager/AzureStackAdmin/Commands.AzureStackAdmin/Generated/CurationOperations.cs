// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.AzureStack.Management;
using Microsoft.AzureStack.Management.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.AzureStack.Management
{
    /// <summary>
    /// Operations on the curation items  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXX.aspx for
    /// more information)
    /// </summary>
    internal partial class CurationOperations : IServiceOperations<AzureStackClient>, ICurationOperations
    {
        /// <summary>
        /// Initializes a new instance of the CurationOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal CurationOperations(AzureStackClient client)
        {
            this._client = client;
        }
        
        private AzureStackClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.AzureStack.Management.AzureStackClient.
        /// </summary>
        public AzureStackClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Lists the curation results
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Result of the curation list operation
        /// </returns>
        public async Task<CurationListResult> ListAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/providers/Microsoft.Gallery/Curation";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=" + Uri.EscapeDataString(this.Client.ApiVersion));
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    CurationListResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new CurationListResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken curationItemsArray = responseDoc;
                            if (curationItemsArray != null && curationItemsArray.Type != JTokenType.Null)
                            {
                                foreach (JToken curationItemsValue in ((JArray)curationItemsArray))
                                {
                                    CurationItem curationItemInstance = new CurationItem();
                                    result.CurationItems.Add(curationItemInstance);
                                    
                                    JToken identityValue = curationItemsValue["identity"];
                                    if (identityValue != null && identityValue.Type != JTokenType.Null)
                                    {
                                        string identityInstance = ((string)identityValue);
                                        curationItemInstance.Identity = identityInstance;
                                    }
                                    
                                    JToken itemUriValue = curationItemsValue["itemUri"];
                                    if (itemUriValue != null && itemUriValue.Type != JTokenType.Null)
                                    {
                                        string itemUriInstance = ((string)itemUriValue);
                                        curationItemInstance.ItemUri = itemUriInstance;
                                    }
                                    
                                    JToken isDefaultValue = curationItemsValue["isDefault"];
                                    if (isDefaultValue != null && isDefaultValue.Type != JTokenType.Null)
                                    {
                                        bool isDefaultInstance = ((bool)isDefaultValue);
                                        curationItemInstance.IsDefault = isDefaultInstance;
                                    }
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
