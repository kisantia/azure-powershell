﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Setup a network profile.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.Network),
    OutputType(
        typeof(PSVirtualMachine))]
    public class SetAzureVMNetworkProfileCommand : AzurePSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VMProfile { get; set; }

        public override void ExecuteCmdlet()
        {
            var networkProfile = new NetworkProfile
            {
                NetworkInterfaces = new List<NetworkInterfaceReference>()
            };

            this.VMProfile.NetworkProfile = networkProfile;

            WriteObject(this.VMProfile);
        }
    }
}
