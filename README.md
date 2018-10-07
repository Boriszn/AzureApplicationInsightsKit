# ![App Insights Icon](https://raw.githubusercontent.com/Boriszn/AzureApplicationInsightsKit/develop/assets/img/appinskit-logo-header-v2.jpg "Azure Application Insights Kit")

[![NuGet Downloads](https://img.shields.io/nuget/v/AzureApplicationInsightsKit.svg)](https://www.nuget.org/packages/AzureApplicationInsightsKit/) [![Build status](https://ci.appveyor.com/api/projects/status/ls8osc1f62e0k3p1?svg=true)](https://ci.appveyor.com/project/Boriszn/azureapplicationinsightskit)

Library (SDK) provides capabilities  to retrieve and query Metrics, Events data from Azure Application Insights.

## Capabilities

1. Metrics: this is a REST API which allows users to retrieve metric data such as the number of exceptions each hour for the last day. It allows users to specify a metric name, a timespan, time intervals, the type of aggregation (sum, average, minimum or maximum) and the property over which to segment the data. There is a corresponding metadata path which returns the available metrics and information about them such as support aggregation types and segmentation properties.

2. Events: this is a REST API which allows users rich capabilities to access their event data using OData syntax. The API supports `$filter`, `$orderBy`, `$search`, `$apply`, `$top`, `$skip` and `$format`, so that it can be used to both return individual event data as well as aggregate over specific sets of events. This also supports $metadata which returns the set of data types and their properties.

3. Query: the query API is designed to enable users API access to the same data using the same queries as they do with Application Insights Analytics. There is also a schema path which returns the schema in which data will be returned.

**[Source of this documentation](https://dev.applicationinsights.io/quickstart)**

## Installation

1. To enable Azure App Insights API support for your Azure resource follow the [API documentation](https://dev.applicationinsights.io/quickstart) and using screenshot below. 
![App Insights Icon](https://raw.githubusercontent.com/Boriszn/AzureApplicationInsightsKit/master/assets/img/api-access.png "App Insights")

2. Clone repository
3. Run UnitTests / Integration tests
4. Build / Run.

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## Tools and Links

- [Model generator app.quicktype.io](https://app.quicktype.io)
- [Azure Application insights quickstart](https://dev.applicationinsights.io/quickstart)
 

## History

All changes can be easily found in [RELEASENOTES](ReleaseNotes.md)

## License

This project is licensed under the MIT License