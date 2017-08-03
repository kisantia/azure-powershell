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
    /// Public gallery items operations.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXX.aspx for
    /// more information)
    /// </summary>
    internal partial class PublicGalleryItemOperations : IServiceOperations<AzureStackClient>, IPublicGalleryItemOperations
    {
        /// <summary>
        /// Initializes a new instance of the PublicGalleryItemOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal PublicGalleryItemOperations(AzureStackClient client)
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
        /// Public gallery items list.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Public gallery items list result.
        /// </returns>
        public async Task<PublicGalleryItemListResult> ListAllAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                TracingAdapter.Enter(invocationId, this, "ListAllAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/providers/Microsoft.Gallery/galleryitems";
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
                    PublicGalleryItemListResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new PublicGalleryItemListResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken galleryItemsArray = responseDoc;
                            if (galleryItemsArray != null && galleryItemsArray.Type != JTokenType.Null)
                            {
                                foreach (JToken galleryItemsValue in ((JArray)galleryItemsArray))
                                {
                                    GalleryItem galleryItemInstance = new GalleryItem();
                                    result.GalleryItems.Add(galleryItemInstance);
                                    
                                    JToken additionalPropertiesSequenceElement = ((JToken)galleryItemsValue["additionalProperties"]);
                                    if (additionalPropertiesSequenceElement != null && additionalPropertiesSequenceElement.Type != JTokenType.Null)
                                    {
                                        foreach (JProperty property in additionalPropertiesSequenceElement)
                                        {
                                            string additionalPropertiesKey = ((string)property.Name);
                                            string additionalPropertiesValue = ((string)property.Value);
                                            galleryItemInstance.AdditionalProperties.Add(additionalPropertiesKey, additionalPropertiesValue);
                                        }
                                    }
                                    
                                    JToken categoryIdsArray = galleryItemsValue["categoryIds"];
                                    if (categoryIdsArray != null && categoryIdsArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken categoryIdsValue in ((JArray)categoryIdsArray))
                                        {
                                            galleryItemInstance.CategoryIds.Add(((string)categoryIdsValue));
                                        }
                                    }
                                    
                                    JToken definitionTemplatesValue = galleryItemsValue["definitionTemplates"];
                                    if (definitionTemplatesValue != null && definitionTemplatesValue.Type != JTokenType.Null)
                                    {
                                        DefinitionTemplates definitionTemplatesInstance = new DefinitionTemplates();
                                        galleryItemInstance.DefinitionTemplates = definitionTemplatesInstance;
                                        
                                        JToken defaultDeploymentTemplateIdValue = definitionTemplatesValue["defaultDeploymentTemplateId"];
                                        if (defaultDeploymentTemplateIdValue != null && defaultDeploymentTemplateIdValue.Type != JTokenType.Null)
                                        {
                                            string defaultDeploymentTemplateIdInstance = ((string)defaultDeploymentTemplateIdValue);
                                            definitionTemplatesInstance.DefaultDeploymentTemplateId = defaultDeploymentTemplateIdInstance;
                                        }
                                        
                                        JToken deploymentFragmentFileUrisSequenceElement = ((JToken)definitionTemplatesValue["deploymentFragmentFileUris"]);
                                        if (deploymentFragmentFileUrisSequenceElement != null && deploymentFragmentFileUrisSequenceElement.Type != JTokenType.Null)
                                        {
                                            foreach (JProperty property2 in deploymentFragmentFileUrisSequenceElement)
                                            {
                                                string deploymentFragmentFileUrisKey = ((string)property2.Name);
                                                string deploymentFragmentFileUrisValue = ((string)property2.Value);
                                                definitionTemplatesInstance.DeploymentFragmentFileUris.Add(deploymentFragmentFileUrisKey, deploymentFragmentFileUrisValue);
                                            }
                                        }
                                        
                                        JToken deploymentTemplateFileUrisSequenceElement = ((JToken)definitionTemplatesValue["deploymentTemplateFileUris"]);
                                        if (deploymentTemplateFileUrisSequenceElement != null && deploymentTemplateFileUrisSequenceElement.Type != JTokenType.Null)
                                        {
                                            foreach (JProperty property3 in deploymentTemplateFileUrisSequenceElement)
                                            {
                                                string deploymentTemplateFileUrisKey = ((string)property3.Name);
                                                string deploymentTemplateFileUrisValue = ((string)property3.Value);
                                                definitionTemplatesInstance.DeploymentTemplateFileUris.Add(deploymentTemplateFileUrisKey, deploymentTemplateFileUrisValue);
                                            }
                                        }
                                        
                                        JToken uiDefinitionFileUriValue = definitionTemplatesValue["uiDefinitionFileUri"];
                                        if (uiDefinitionFileUriValue != null && uiDefinitionFileUriValue.Type != JTokenType.Null)
                                        {
                                            string uiDefinitionFileUriInstance = ((string)uiDefinitionFileUriValue);
                                            definitionTemplatesInstance.UiDefinitionFileUri = uiDefinitionFileUriInstance;
                                        }
                                    }
                                    
                                    JToken descriptionValue = galleryItemsValue["description"];
                                    if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                                    {
                                        string descriptionInstance = ((string)descriptionValue);
                                        galleryItemInstance.Description = descriptionInstance;
                                    }
                                    
                                    JToken identityValue = galleryItemsValue["identity"];
                                    if (identityValue != null && identityValue.Type != JTokenType.Null)
                                    {
                                        string identityInstance = ((string)identityValue);
                                        galleryItemInstance.Identity = identityInstance;
                                    }
                                    
                                    JToken itemDisplayNameValue = galleryItemsValue["itemDisplayName"];
                                    if (itemDisplayNameValue != null && itemDisplayNameValue.Type != JTokenType.Null)
                                    {
                                        string itemDisplayNameInstance = ((string)itemDisplayNameValue);
                                        galleryItemInstance.ItemDisplayName = itemDisplayNameInstance;
                                    }
                                    
                                    JToken itemNameValue = galleryItemsValue["itemName"];
                                    if (itemNameValue != null && itemNameValue.Type != JTokenType.Null)
                                    {
                                        string itemNameInstance = ((string)itemNameValue);
                                        galleryItemInstance.ItemName = itemNameInstance;
                                    }
                                    
                                    JToken linksArray = galleryItemsValue["links"];
                                    if (linksArray != null && linksArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken linksValue in ((JArray)linksArray))
                                        {
                                            LinkProperties linkPropertiesInstance = new LinkProperties();
                                            galleryItemInstance.Links.Add(linkPropertiesInstance);
                                            
                                            JToken displayNameValue = linksValue["displayName"];
                                            if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                                            {
                                                string displayNameInstance = ((string)displayNameValue);
                                                linkPropertiesInstance.DisplayName = displayNameInstance;
                                            }
                                            
                                            JToken idValue = linksValue["id"];
                                            if (idValue != null && idValue.Type != JTokenType.Null)
                                            {
                                                string idInstance = ((string)idValue);
                                                linkPropertiesInstance.Id = idInstance;
                                            }
                                            
                                            JToken uriValue = linksValue["uri"];
                                            if (uriValue != null && uriValue.Type != JTokenType.Null)
                                            {
                                                string uriInstance = ((string)uriValue);
                                                linkPropertiesInstance.Uri = uriInstance;
                                            }
                                        }
                                    }
                                    
                                    JToken longSummaryValue = galleryItemsValue["longSummary"];
                                    if (longSummaryValue != null && longSummaryValue.Type != JTokenType.Null)
                                    {
                                        string longSummaryInstance = ((string)longSummaryValue);
                                        galleryItemInstance.LongSummary = longSummaryInstance;
                                    }
                                    
                                    JToken publisherValue = galleryItemsValue["publisher"];
                                    if (publisherValue != null && publisherValue.Type != JTokenType.Null)
                                    {
                                        string publisherInstance = ((string)publisherValue);
                                        galleryItemInstance.Publisher = publisherInstance;
                                    }
                                    
                                    JToken publisherDisplayNameValue = galleryItemsValue["publisherDisplayName"];
                                    if (publisherDisplayNameValue != null && publisherDisplayNameValue.Type != JTokenType.Null)
                                    {
                                        string publisherDisplayNameInstance = ((string)publisherDisplayNameValue);
                                        galleryItemInstance.PublisherDisplayName = publisherDisplayNameInstance;
                                    }
                                    
                                    JToken resourceGroupNameValue = galleryItemsValue["resourceGroupName"];
                                    if (resourceGroupNameValue != null && resourceGroupNameValue.Type != JTokenType.Null)
                                    {
                                        string resourceGroupNameInstance = ((string)resourceGroupNameValue);
                                        galleryItemInstance.ResourceGroupName = resourceGroupNameInstance;
                                    }
                                    
                                    JToken screenshotUrisArray = galleryItemsValue["screenshotUris"];
                                    if (screenshotUrisArray != null && screenshotUrisArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken screenshotUrisValue in ((JArray)screenshotUrisArray))
                                        {
                                            galleryItemInstance.ScreenshotUris.Add(((string)screenshotUrisValue));
                                        }
                                    }
                                    
                                    JToken summaryValue = galleryItemsValue["summary"];
                                    if (summaryValue != null && summaryValue.Type != JTokenType.Null)
                                    {
                                        string summaryInstance = ((string)summaryValue);
                                        galleryItemInstance.Summary = summaryInstance;
                                    }
                                    
                                    JToken versionValue = galleryItemsValue["version"];
                                    if (versionValue != null && versionValue.Type != JTokenType.Null)
                                    {
                                        string versionInstance = ((string)versionValue);
                                        galleryItemInstance.Version = versionInstance;
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
