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

using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class NewAzureRmSnapshotUpdateConfigCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete.  CreateOption cannot be changed during updating a snapshot." +
            "To set the CreateOption of a snapshot, use New-AzureRmSnapshotConfig command.",
            false)]
        public DiskCreateOption? CreateOption { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete.  StorageAccountId cannot be changed during updating a snapshot." +
            "To set the StorageAccountId of a snapshot, use New-AzureRmSnapshotConfig command.",
            false)]
        public string StorageAccountId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete.  ImageReference cannot be changed during updating a snapshot." +
            "To set the ImageReference of a snapshot, use New-AzureRmSnapshotConfig command.",
            false)]
        public ImageDiskReference ImageReference { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete.  SourceUri cannot be changed during updating a snapshot." +
            "To set the SourceUri of a snapshot, use New-AzureRmSnapshotConfig command.",
            false)]
        public string SourceUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete.  SourceResourceId cannot be changed during updating a snapshot." +
            "To set the SourceResourceId of a snapshot, use New-AzureRmSnapshotConfig command.",
            false)]
        public string SourceResourceId { get; set; }
    }
}

