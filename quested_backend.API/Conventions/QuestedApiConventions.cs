﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace quested_backend.Conventions
{
    /// <summary>
    /// Set of api conventions for defining a proper contract of Quested API
    /// </summary>
    public static class QuestedApiConventions
    {
        [ProducesResponseType(200)]
        [ProducesResponseType(405)]
        [ProducesDefaultResponseType]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Get([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
        {
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(405)]
        [ProducesDefaultResponseType]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void GetById([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                    ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
        {
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(405)]
        [ProducesDefaultResponseType]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Create([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any),
                                   ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
        {
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(405)]
        [ProducesDefaultResponseType]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Update([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                   ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id, [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any),
                        ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
        {
        }


        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(405)]
        [ProducesDefaultResponseType]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Delete([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                   ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
        {
        }
    }
}