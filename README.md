# TVScheduler
 A Web API for managing the schedule of a TV channel. The API should provides functionality for adding, retrieving, and deleting information about TV programs within the channel. 
 
## Usage
In order to run the application, make sure that the db exists and connection string is added into appsettings.json file in TVScheduler.WebApi project.

## Request example
You can use swagger for convenience (/swagger/index.html), but here is an example of POST request for program creation:
_/api/channel/{channelId}/program_
```json
{
  "name": "Some program",
  "description": "your description",
  "startTime": "2024-02-20T10:45:18",
  "endTime": "2024-03-20T10:45:18"
}
```
Please, pay attention that the milliseconds in dates will be trimmed for convenience. Also, end time should be later than start time. Description may be omitted.

