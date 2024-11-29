
# Hacker News Best Stories API

This REST API project fetches the top `n` stories from Hacker News, sorted by their score. It integrates with the Hacker News API and employs caching for performance optimization.

---

## Features

- Retrieve the top `n` stories from Hacker News with detailed information.
- In-memory caching to optimize performance and reduce external API calls.
- Implements CQRS architecture using MediatR.
- Includes Swagger for API documentation.

---

## Prerequisites

- **.NET 8 SDK**: [Download .NET](https://dotnet.microsoft.com/download)
- **IDE**: Visual Studio, Rider, or Visual Studio Code with C# extensions.

---

## Getting Started

### Clone the Repository
```bash
git clone https://github.com/tipejn/HackerNewsBestStories.git
cd HackerNewsBestStories
cd HackerNewsBestStories.Api
```

### Restore Dependencies
```bash
dotnet restore
```

### Build the Application
```bash
dotnet build
```

### Run the Application
```bash
dotnet run
```

### Access the API
- API base URL: `https://localhost:5202`
- Swagger documentation: `https://localhost:5202/swagger`

---

## API Endpoints

### **GET** `/api/Story`

Fetch the top `n` stories from Hacker News.

**Query Parameters**:
- `count` (optional, default: 10): The number of top stories to retrieve.

**Example Request**:
```http
GET /api/Story?count=5
```

**Response**:
```json
[
  {
    "title": "Malware can turn off webcam LED and record video, demonstrated on ThinkPad X230",
    "uri": "https://github.com/xairy/lights-out",
    "postedBy": "xairy",
    "time": "2024-11-27T20:10:55.0000000+00:00",
    "score": 995,
    "commentCount": 505
  }
]
```

**Error Responses**:
- `400 Bad Request`: If the `count` parameter is invalid.
- `500 Internal Server Error`: If an unexpected error occurs.

---

## Assumptions

1. **Hacker News API Reliability**:
   - Assumes the external Hacker News API is available and returns consistent responses.

2. **Caching**:
   - In-memory caching is used for better performance. A distributed cache (e.g., Redis) would be more appropriate in a distributed environment.

3. **Default Story Count**:
   - If the `count` parameter is not provided, the API defaults to returning the top 10 stories.

---

## Enhancements and Future Improvements

### Possible Enhancements
1. **Error Handling**:
   - Handle rate limits, API timeouts, and other transient issues more gracefully.

2. **Distributed Cache**:
   - Use Redis or another distributed caching system for scalability.

3. **Persistent Storage**:
   - Introduce a database to store frequently accessed stories.

4. **Rate Limiting**:
   - Implement rate limiting to prevent abuse of the API.

5. **Telemetry and Logging**:
   - Integrate with logging systems like Serilog and telemetry platforms like Application Insights.

6. **Testing**:
   - Add comprehensive unit tests, integration tests, and load tests.

---

## Technologies Used

- **ASP.NET Core 8.0**: For building the RESTful API.
- **MediatR**: For implementing CQRS patterns.
- **Swagger**: For API documentation.
- **Microsoft.Extensions.Caching.Memory**: For caching.


