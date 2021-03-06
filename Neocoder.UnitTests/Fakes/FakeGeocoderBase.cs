﻿// <copyright file="FakeGeocoderBase.cs" company="GeneGenie.com">
// Copyright (c) GeneGenie.com. All Rights Reserved.
// Licensed under the GNU Affero General Public License v3.0. See LICENSE in the project root for license information.
// </copyright>

namespace Neocoder.UnitTests.Fakes
{
    using System;
    using System.Collections.Generic;
    using Neocoder.Services;

    public class FakeGeocoderBase
    {
        internal Dictionary<GeocoderNames, GeocodeStatus> ExtractStatusFromAddress(string address)
        {
            var statusList = new Dictionary<GeocoderNames, GeocodeStatus>();
            var splitByGeocoder = address.Split(";");

            foreach (var statusPair in splitByGeocoder)
            {
                var splitByNameAndStatus = statusPair.Split("=");

                var geocoderId = Enum.Parse<GeocoderNames>(splitByNameAndStatus[0], true);
                var geocoderStatus = Enum.Parse<GeocodeStatus>(splitByNameAndStatus[1], true);

                statusList.Add(geocoderId, geocoderStatus);
            }

            return statusList;
        }
    }
}
