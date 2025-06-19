# openDSRIP
*A Vendor-Agnostic Platform for Orchestrating Demand-Side Energy Resources*

![.NET Core](https://img.shields.io/badge/.NET_Core-3.1-blue)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Architecture Overview](#architecture-overview)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Configuration](#configuration)
- [Architecture Details](#architecture-details)
- [Testing](#testing)
- [License](#license)
- [Credits & Acknowledgements](#credits--acknowledgements)

## Introduction
**openDSRIP** (Open Demand Side Resource Integration Platform) is an open-source, vendor-agnostic platform designed to enable seamless orchestration of distributed demand-side energy resources (DERs). Originally developed by EPRI through an EPIC grant from the California Energy Commission, openDSRIP allows utilities, aggregators, and other energy stakeholders to efficiently coordinate and control diverse resources such as smart thermostats, batteries, electric water heaters, and EV chargers.

The platform provides a scalable and interoperable solution that integrates demand response, pricing signals, and event-driven orchestration using industry standards like OpenADR and IEEE 2030.5.

By enabling automated control and resource aggregation, **openDSRIP** supports grid stability, enhances demand flexibility, and paves the way for customer-centric energy programs.

## Features
- ✅ **Vendor-Agnostic Integration**: Supports diverse demand-side resources regardless of manufacturer.
- 🔌 **Standards-Based API Support**: Implements OpenADR and IEEE 2030.5 protocols for grid events and pricing signals.
- 🔐 **Secure Authentication**: Uses OAuth 2.0 for robust access management.
- ⚙️ **Modular Architecture**: Clean separation of concerns across controllers, models, and services.
- 🗄️ **Database Support**: MySQL-backed storage with Entity Framework Core ORM.
- 📊 **Orchestration Engine**: Aggregates resources and automates their control based on predefined grid events.
- 📚 **Extensible Design**: Ready for future enhancements like residential orchestration modules (ROM), advanced analytics, and Azure cloud integration.

## Architecture Overview
The openDSRIP platform follows a **modular, service-oriented architecture** built with ASP.NET Core. It is designed for flexibility, scalability, and secure orchestration of diverse demand-side energy resources.

### Key Components
- **RESTful API Layer**: Handles all client requests and routes them to appropriate services using ASP.NET Core Controllers.
- **Authentication Module**: Implements OAuth 2.0 to securely authenticate users and services.
- **Orchestration Engine**: Aggregates demand-side resources and automates event-driven control based on pricing signals or grid events.
- **Database Layer**: Utilizes MySQL for persistent storage of resources, event logs, user data, and orchestration configurations, accessed via Entity Framework Core (EF Core).
- **Standards Integration**: Supports key energy protocols such as OpenADR and IEEE 2030.5 to ensure interoperability with third-party systems and grid operators.

## Getting Started

Follow these steps to set up, build, and run the openDSRIP application on your local machine.

### Prerequisites
Before you begin, make sure you have the following installed:
- [.NET Core SDK 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- MySQL Server
- (Optional) Postman or cURL for API testing

---

### Installation

1. **Clone the Repository**
    ```bash
    git clone https://github.com/eprissankara73/openDSRIP.git
    cd openDSRIP

2. **Configure the Application**
    Open the appsettings.json file and update the MYSQL connection string:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "server=localhost;database=dsrip;user=root;password=yourpassword;"
    }
    ```

3. **Setting up the database**
    Set Up the Database
    If the project provides an initial SQL schema, execute it on your MySQL server.
    Alternatively, run Entity Framework Core migrations to create the required tables:
    ```bash
    dotnet ef database update
    ```

4. **Build the application**
    ```bash
    dotnet build
    ```

5. **Run the application**
    ```bash
    dotnet run
    ```

    The API should be accessible at:
    https://localhost:5001

### Notes
- Make sure your MySQL server is running and accessible.

- You can use tools like Postman or Swagger UI (if configured) to interact with and test the API.

- For production deployment, update OAuth security settings and use HTTPS with a valid certificate.

### Troubleshooting
- **Database Connection Errors:** Verify that your MySQL connection string is correct and that the database server is running.

- **Port Conflicts:** Change the urls setting in launchSettings.json if port 5001 is already in use.

---

## Usage

Once the openDSRIP application is running, you can interact with its API endpoints to manage resources, trigger events, and orchestrate demand-side responses.

---

### Base URL
The API is accessible at:
https://localhost:5001


*(Adjust the base URL if you’ve configured a different port or deployment environment.)*

---

### Authentication
All endpoints are secured using **OAuth 2.0**. You must obtain an access token from your configured OAuth provider before making requests.

Example token request (if using client credentials flow):
```http
POST /connect/token
Content-Type: application/x-www-form-urlencoded
```

client_id=<your-client-id>
client_secret=<your-client-secret>
grant_type=client_credentials

Use the obtained `access_token` as a Bearer Token in Authorization Header
```http
Authorization: Bearer <access_token>
```
---

## Configuration

The openDSRIP platform is configured using the `appsettings.json` file, which contains settings for database connections, authentication, logging, and application-specific parameters.

---

### Key Configuration Settings

#### 1. Database Connection
Update the `ConnectionStrings` section in `appsettings.json` to point to your MySQL server.

```json
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=dsrip;user=root;password=yourpassword;"
}
```
#### 2. OAuth2 Settings
Configure the OAuth authentication settings to match your identify provider. Example:
```json
"OAuth": {
    "Authority": "https://your-auth-server.com",
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret",
    "Scopes": [ "api.read", "api.write" ]
}
```
These values should align with the OAuth 2.0 provider you are using (e.g., IdentityServer, Auth0, Azure AD).

## Architecture Details

The openDSRIP application follows a modular, service-oriented architecture using clean separation of concerns to improve maintainability and scalability.

---

### High-Level Architecture

- **Presentation Layer:**  
  Exposes RESTful APIs for clients to interact with the system. Handles incoming requests, authentication, and response formatting.

- **Business Logic Layer:**  
  Contains core services that manage resource registration, demand response orchestration, and event processing.

- **Data Access Layer:**  
  Uses Entity Framework Core to interact with a MySQL database. Implements repository patterns for clean and testable data access.

- **Authentication Layer:**  
  Integrates with OAuth 2.0 providers to secure API endpoints using bearer tokens.

- **External Interfaces:**  
  Supports integration with external systems like resource managers, building automation systems, and third-party event sources.

---

### Technology Stack

| Layer                 | Technology                  |
|-----------------------|-----------------------------|
| API Framework         | ASP.NET Core Web API        |
| Database ORM          | Entity Framework Core       |
| Database              | MySQL                       |
| Authentication        | OAuth 2.0                   |


---

### Key Design Patterns

- **Repository Pattern:**  
  Provides abstraction over data persistence logic.

- **Dependency Injection:**  
  Used extensively to inject services and repositories into controllers for loose coupling.

- **Asynchronous Programming:**  
  Leverages `async/await` to improve scalability and responsiveness.

- **Configuration Binding:**  
  Maps settings from `appsettings.json` to strongly-typed configuration classes.

---

### Extensibility

- New event types and resource types can easily be added by extending service and model layers.
- Authentication can be swapped or enhanced to support other protocols like OpenID Connect.
- Database support can be extended to other relational systems with minor changes.

---

### Security Notes

- All APIs require OAuth 2.0 authentication.
- HTTPS should always be used in production environments.
- Sensitive information like client secrets should be stored in environment variables or secure vaults.

### Data Model and API Documentation
#### 🔋 Battery API and Data Model Documentation

##### 📦 Battery Data Model

Represents a battery entity associated with a site.

###### 🔸 Field Definitions

| Field       | Type    | Description                        |
|-------------|---------|----------------------------------|
| `SiteId`    | string  | Identifier for the associated site |
| `BatteryId` | string  | Unique identifier for the battery  |
| `Name`      | string  | Name of the battery               |
| `Type`      | string  | Type or classification of the battery |

---

##### 🔌 Battery API Documentation

**Base Route:** `/api/DSRIPBattery`

###### 📥 GET `/api/DSRIPBattery`

**Description:**  
Retrieves battery records based on query parameters:

- If **no parameters** are provided → returns `Not Found`.  
- If **only `SiteId`** is provided → returns all batteries for that site.  
- If **both `SiteId` and `BatteryId`** are provided → returns the specific battery.

**Query Parameters:**

| Parameter  | Required | Description                          |
|------------|----------|------------------------------------|
| `SiteId`   | No       | The ID of the site to filter batteries |
| `BatteryId`| No       | The ID of a specific battery        |

**Examples:**

- Get all batteries for a site:  
    ```http
    GET /api/DSRIPBattery?SiteId=site001
    ```
- Get a specific battery:
    ```http
    GET /api/DSRIPBattery?SiteId=site001&BatteryId=bat001
    ```
**Response Examples**
- Batteries for a site:
    ```json
    [
    {
        "SiteId": "site001",
        "BatteryId": "bat001",
        "Name": "Battery A",
        "Type": "Li-Ion"
    }
    ]
    ```
- Specific Battery:
    ```json
    {
        "SiteId": "site001",
        "BatteryId": "bat001",
        "Name": "Battery A",
        "Type": "Li-Ion"
    }
    ```
###### 🛠️ POST `/api/DSRIPBattery`

**Description:**
Adds a new battery to the system.

**Request Body Example:**
```json
{
  "SiteId": "site003",
  "Name": "Battery C",
  "Type": "Li-Ion"
}
```

**Response Example:**
```json
{
  "siteId": "site003",
  "batteryId": "<Battery GUID>" ,
  "name": "Battery C",
  "type": "Li-Ion"
}
```

###### ✏️ PUT `/api/DSRIPBattery/{BatteryId}`

**Description:**
Updates an existing battery identified by `{BatteryId}`.

**Request Example:**
```json
{
  "SiteId": "site003",
  "BatteryId": "<Battery GUID>",
  "Name": "Battery C - Updated",
  "Type": "Li-Ion"
}
```
**Response:**
`204 No Content` (Updated Successful)

###### ❌ DELETE `/api/DSRIPBattery/{BatteryId}`
**Description:**
Deletes a battery identified by `BatteryId`.

**Response:**
`204 No Content` (Successful Deletion)

#### 🔋 BatteryReading API and Data Model Documentation

##### 📦 BatteryReading Data Model

Represents a reading at a particular timestamp for a battery entity associated with a site.

###### 🔸 Field Definitions

| Field Name         | Data Type | Description                                                 |
| ------------------ | --------- | ----------------------------------------------------------- |
| `BatteryReadingId` | String    | Unique identifier for the battery reading (auto-generated). |
| `BatteryId`        | String    | Identifier of the battery associated with this reading.     |
| `SiteId`           | String    | Identifier of the site.                                     |
| `Time`             | String    | Timestamp of the battery reading.                           |
| `ConsumptionWatts` | String    | Power consumption in watts.                                 |
| `Frequency`        | String    | System frequency.                                           |
| `IntervalPower`    | String    | Power used in the interval.                                 |
| `ProductionWatts`  | String    | Power production in watts.                                  |
| `StateOfCharge`    | String    | Battery charge percentage.                                  |
| `AcVoltage`        | String    | AC voltage value.                                           |
| `BatteryVoltage`   | String    | Battery DC voltage value.                                   |

---

##### 🔌 BatteryReading API Documentation

**Base Route:** `/api/DSRIPBatteryReading`

###### 📥 GET `/api/DSRIPBatteryReading`

**Description:**  
Retrieve battery readings for a specific battery within a specified time range.

**Query Parameters:**

| Parameter  | Required | Description                                                  | 
|------------|----------|--------------------------------------------------------------|
| `BatteryId`| Yes       | The ID of a specific battery                                |
| `startTime`| Yes       | The starting timestamp in yyyy-mm-dd hh:mm:ss format        |
| `endTime`| Yes       | The starting timestamp in yyyy-mm-dd hh:mm:ss format        |


**Examples:**

- Get a specific battery readings:
    ```http
    GET /api/DSRIPBatteryReading?batteryId=123&startTime=2024-01-01%2000:00:00&endTime=2024-01-02%2000:00:00
    ```
**Response Examples**
```json
[
    {
        "batteryReadingId": "abcd-1234",
        "batteryId": "123",
        "siteId": "SiteA",
        "time": "2024-01-01T01:00:00",
        "consumptionWatts": "500",
        "frequency": "60",
        "intervalPower": "50",
        "productionWatts": "200",
        "stateOfCharge": "80",
        "acVoltage": "240",
        "batteryVoltage": "48"
    }
]    
```

###### 🛠️ POST `/api/DSRIPBatteryReading`

**Description:**
Create new battery reading records.

**Request Body Example:**
```json
[
    {
        "batteryId": "123",
        "siteId": "SiteA",
        "time": "2024-01-01T01:00:00",
        "consumptionWatts": "500",
        "frequency": "60",
        "intervalPower": "50",
        "productionWatts": "200",
        "stateOfCharge": "80",
        "acVoltage": "240",
        "batteryVoltage": "48"
    }
]
```

**Response Example:**
```json
{
    "batteryReadingId": "<generated-GUID>",
    "batteryId": "123",
    "siteId": "SiteA",
    "time": "2024-01-01T01:00:00",
    "consumptionWatts": "500",
    "frequency": "60",
    "intervalPower": "50",
    "productionWatts": "200",
    "stateOfCharge": "80",
    "acVoltage": "240",
    "batteryVoltage": "48"
}
```

###### ✏️ PUT `/api/DSRIPBatteryReading`

**Description:**
Updates an existing batteryReading identified by query parameter `{id}`.

**Query Parameters:**

| Parameter  | Required | Description                                                  | 
|------------|----------|--------------------------------------------------------------|
| `id`       | Yes      | The unique ID of the battery reading to be updated           |

```http
PUT api/DSRIPBatteryReading?id=batr1001
```

**Request Example:**
```json
{
    "batteryReadingId": "abcd-1234",
    "batteryId": "123",
    "siteId": "SiteA",
    "time": "2024-01-01T01:00:00",
    "consumptionWatts": "600",
    "frequency": "60",
    "intervalPower": "55",
    "productionWatts": "210",
    "stateOfCharge": "85",
    "acVoltage": "240",
    "batteryVoltage": "48"
}
```
###### ❌ DELETE `/api/DSRIPBatteryReading`
**Description:**
Deletes a battery reading identified by query parameter `id`.

**Query Parameters:**

| Parameter  | Required | Description                                                  | 
|------------|----------|--------------------------------------------------------------|
| `id`       | Yes      | The unique ID of the battery reading to be deleted           |

```http
DELETE api/DSRIPBatteryReading?id=batr1001
```

**Response:**
```json
{
    "batteryReadingId": "abcd-1234",
    "batteryId": "123",
    "siteId": "SiteA",
    "time": "2024-01-01T01:00:00",
    "consumptionWatts": "500",
    "frequency": "60",
    "intervalPower": "50",
    "productionWatts": "200",
    "stateOfCharge": "80",
    "acVoltage": "240",
    "batteryVoltage": "48"
}
```

#### Electric Vehicle Data Model and API Documentation

##### Data Model: ElectricVehicle

| Attribute           | Type   | Description                  |
|---------------------|--------|------------------------------|
| SiteId              | string | Identifier of the site       |
| ElectricVehicleId   | string | Unique identifier for the EV |
| Name                | string | Name of the EV               |
| Vin                 | string | Vehicle Identification Number |
| NickName            | string | Nickname for the EV          |

---

##### API Endpoints

###### GET Electric Vehicles

**Endpoint:** `GET /api/DSRIPElectricVehicle`

**Query Parameters:**
- `siteId` (required if `evId` is not provided): Site identifier.
- `evId` (optional): Electric vehicle identifier.

**Behavior:**
- If both `siteId` and `evId` are missing, the API returns `404 Not Found`.
- If only `siteId` is provided, returns all electric vehicles for the site.
- If both `siteId` and `evId` are provided, returns the specific electric vehicle.

**Example Requests:**
```http
GET /api/DSRIPElectricVehicle?siteId=Site123

GET /api/DSRIPElectricVehicle?siteId=Site123&evId=EV456
```

**Example Response:**
```json
[
    {
        "siteId": "Site123",
        "electricVehicleId": "EV456",
        "name": "Tesla Model S",
        "vin": "5YJSA1E26JF123456",
        "nickName": "My Tesla"
    }
]
```

---

###### POST Electric Vehicle

**Endpoint:** `POST /api/DSRIPElectricVehicle`

**Request Body:**
```json
{
    "siteId": "Site123",
    "name": "Tesla Model S",
    "vin": "5YJSA1E26JF123456",
    "nickName": "My Tesla"
}
```

**Response:**
```json
{
    "siteId": "Site123",
    "electricVehicleId": "Generated-GUID",
    "name": "Tesla Model S",
    "vin": "5YJSA1E26JF123456",
    "nickName": "My Tesla"
}
```

---

###### PUT Electric Vehicle

**Endpoint:** `PUT /api/DSRIPElectricVehicle/{id}`

**Request Body:**
```json
{
    "siteId": "Site123",
    "electricVehicleId": "EV456",
    "name": "Tesla Model X",
    "vin": "5YJXCDE26GF123456",
    "nickName": "Updated Tesla"
}
```

**Response:** `204 No Content`

---

###### DELETE Electric Vehicle

**Endpoint:** `DELETE /api/DSRIPElectricVehicle`

**Query Parameter:**
- `evId`: Electric vehicle identifier to delete.

**Example Request:**
```http
DELETE /api/DSRIPElectricVehicle?evId=EV456
```

**Example Response:**
```json
{
    "siteId": "Site123",
    "electricVehicleId": "EV456",
    "name": "Tesla Model S",
    "vin": "5YJSA1E26JF123456",
    "nickName": "My Tesla"
}
```

#### 🔋 ElectricVehicleReading API and Data Model Documentation

##### 📦 ElectricVehicleReading Data Model

Represents a reading at a particular timestamp for an EV associated with a site.

###### 🔸 Field Definitions

| Field Name                  | Type    | Description                                |
| --------------------------- | ------- | ------------------------------------------ |
| electricVehicleReadingId    | string  | Unique ID of the reading                   |
| electricVehicleId           | string  | Associated Electric Vehicle ID             |
| siteId                      | string  | Site ID                                    |
| time                        | string  | Timestamp of the reading                   |
| batteryCapacityAndRange     | integer | Battery capacity and range                 |
| stateOfCharge               | integer | Current battery state of charge (%)        |
| desiredStateOfCharge        | string  | Desired state of charge                    |
| chargingState               | string  | Charging state                             |
| latitude                    | integer | Latitude location                          |
| longitude                   | integer | Longitude location                         |
| chargerPilotCurrent         | integer | Pilot current setting                      |
| chargerPilotActual          | integer | Actual pilot current                       |
| chargerVoltage              | integer | Charger voltage                            |
| chargerPower                | integer | Charging power in watts                    |
| timeUntilFullCharge         | integer | Estimated time until full charge           |
| chargerPhase                | string  | Charger phase setting                      |
| superCharger                | string  | Indicates supercharger use                 |
| scheduledChargingPending    | string  | Indicates if scheduled charging is pending |
| scheduledChargingStartTime  | string  | Scheduled charging start time              |
| speed                       | integer | Vehicle speed                              |
| odometer                    | integer | Odometer reading                           |
| insideTemperature           | integer | Inside vehicle temperature                 |
| outsideTemperature          | integer | Outside temperature                        |
| smartPreConditioningEnabled | string  | Smart pre-conditioning status              |

---

##### 🔌 ElectricVehicleReading API Documentation

**Base Route:** `/api/DSRIPElectricVehicleReading`

###### 📥 GET `/api/DSRIPElectricVehicleReading`

**Description:**  
Retrieve readings for a specific EV within a specified time range.

**Query Parameters:**

| Parameter  | Required  | Description                                                  | 
|------------|-----------|--------------------------------------------------------------|
| `eVId`     | Yes       | The ID of a specific EV                                      |
| `startTime`| Yes       | The starting timestamp in yyyy-mm-dd hh:mm:ss format         |
| `endTime`  | Yes       | The starting timestamp in yyyy-mm-dd hh:mm:ss format         |

**Response**
```json
[
  {
    "electricVehicleReadingId": "string",
    "electricVehicleId": "string",
    "siteId": "string",
    "time": "string",
    "batteryCapacityAndRange": 0,
    "stateOfCharge": 0,
    "desiredStateOfCharge": "string",
    "chargingState": "string",
    "latitude": 0,
    "longitude": 0,
    "chargerPilotCurrent": 0,
    "chargerPilotActual": 0,
    "chargerVoltage": 0,
    "chargerPower": 0,
    "timeUntilFullCharge": 0,
    "chargerPhase": "string",
    "superCharger": "string",
    "scheduledChargingPending": "string",
    "scheduledChargingStartTime": "string",
    "speed": 0,
    "odometer": 0,
    "insideTemperature": 0,
    "outsideTemperature": 0,
    "smartPreConditioningEnabled": "string"
  }
]    
```

###### 🛠️ POST `/api/DSRIPElectricVehicleReading`

**Description:**
Create new EV reading records.

**Request Body Example:**
```json
[
  {
    "electricVehicleId": "string",
    "siteId": "string",
    "time": "string",
    "batteryCapacityAndRange": 0,
    "stateOfCharge": 0,
    "desiredStateOfCharge": "string",
    "chargingState": "string",
    "latitude": 0,
    "longitude": 0,
    "chargerPilotCurrent": 0,
    "chargerPilotActual": 0,
    "chargerVoltage": 0,
    "chargerPower": 0,
    "timeUntilFullCharge": 0,
    "chargerPhase": "string",
    "superCharger": "string",
    "scheduledChargingPending": "string",
    "scheduledChargingStartTime": "string",
    "speed": 0,
    "odometer": 0,
    "insideTemperature": 0,
    "outsideTemperature": 0,
    "smartPreConditioningEnabled": "string"
  }
]
```

**Response:**
```json
{
  "electricVehicleReadingId": "string",
  "electricVehicleId": "string",
  "siteId": "string",
  "time": "string",
  "batteryCapacityAndRange": 0,
  "stateOfCharge": 0,
  "desiredStateOfCharge": "string",
  "chargingState": "string",
  "latitude": 0,
  "longitude": 0,
  "chargerPilotCurrent": 0,
  "chargerPilotActual": 0,
  "chargerVoltage": 0,
  "chargerPower": 0,
  "timeUntilFullCharge": 0,
  "chargerPhase": "string",
  "superCharger": "string",
  "scheduledChargingPending": "string",
  "scheduledChargingStartTime": "string",
  "speed": 0,
  "odometer": 0,
  "insideTemperature": 0,
  "outsideTemperature": 0,
  "smartPreConditioningEnabled": "string"
}
```

###### ✏️ PUT `/api/DSRIPElectricVehicleReading`

**Description:**
Updates an existing ElectricVehicleReading identified by query parameter `{id}`.

**Query Parameters:**

| Parameter  | Required | Description                                                  | 
|------------|----------|--------------------------------------------------------------|
| `id`       | Yes      | The unique ID of the EV reading to be updated                |

```http
PUT /api/DSRIPElectricVehicleReading?id={electricVehicleReadingId}
```

**Request Example:**
```json
{
  "electricVehicleReadingId": "string",
  "electricVehicleId": "string",
  "siteId": "string",
  "time": "string",
  "batteryCapacityAndRange": 0,
  "stateOfCharge": 0,
  "desiredStateOfCharge": "string",
  "chargingState": "string",
  "latitude": 0,
  "longitude": 0,
  "chargerPilotCurrent": 0,
  "chargerPilotActual": 0,
  "chargerVoltage": 0,
  "chargerPower": 0,
  "timeUntilFullCharge": 0,
  "chargerPhase": "string",
  "superCharger": "string",
  "scheduledChargingPending": "string",
  "scheduledChargingStartTime": "string",
  "speed": 0,
  "odometer": 0,
  "insideTemperature": 0,
  "outsideTemperature": 0,
  "smartPreConditioningEnabled": "string"
}
```
**Response**
`204 No Content` (Successful Update) 

###### ❌ DELETE `/api/DSRIPElectricVehicleReading`
**Description:**
Deletes an EV reading identified by query parameter `id`.

**Query Parameters:**

| Parameter  | Required | Description                                                  | 
|------------|----------|--------------------------------------------------------------|
| `id`       | Yes      | The unique ID of the EV reading to be deleted                |

```http
DELETE /api/DSRIPElectricVehicleReading?id={electricVehicleReadingId}
```

**Response:**
```json
{
  "electricVehicleReadingId": "string",
  "electricVehicleId": "string",
  "siteId": "string",
  "time": "string",
  "batteryCapacityAndRange": 0,
  "stateOfCharge": 0,
  "desiredStateOfCharge": "string",
  "chargingState": "string",
  "latitude": 0,
  "longitude": 0,
  "chargerPilotCurrent": 0,
  "chargerPilotActual": 0,
  "chargerVoltage": 0,
  "chargerPower": 0,
  "timeUntilFullCharge": 0,
  "chargerPhase": "string",
  "superCharger": "string",
  "scheduledChargingPending": "string",
  "scheduledChargingStartTime": "string",
  "speed": 0,
  "odometer": 0,
  "insideTemperature": 0,
  "outsideTemperature": 0,
  "smartPreConditioningEnabled": "string"
}
```

#### Loads API and Data Model Documentation

##### Overview
The Loads API provides access to load-related data for various sites. It supports CRUD (Create, Read, Update, Delete) operations on load entities via RESTful endpoints.

---

##### API Endpoints

###### GET: Retrieve Load(s)
- **URL:** `api/DSRIPLoads`
- **Method:** GET
- **Authorization:** Required

**Query Parameters:**
- `siteId` (optional if `loadId` provided): ID of the site to retrieve loads for.
- `loadId` (optional if `siteId` provided): ID of a specific load to retrieve.

**Behavior:**
- If both `siteId` and `loadId` are null, returns `404 Not Found`.
- If only `siteId` is provided, returns all loads associated with that site.
- If `loadId` is provided, returns the specific load details.

**Example Response to GET:**
```http
GET /api/DSRIPLoads?siteId={optional siteId}&&loadId={optional loadId}
```

```json
    {
        "SiteId": "site123",
        "LoadId": "Load123",
        "Name": "Load A",
        "Type": "Lighting"
    }
```
---

###### POST: Create New Loads
- **URL:** `api/DSRIPLoads`
- **Method:** POST
- **Authorization:** Required

**Request Body:**
- List of Load objects to be created.

**Behavior:**
- Generates a unique `LoadId` for each new load.
- Adds all new loads to the database.

**Response:**
- Returns the last created load with HTTP `201 Created` status.

**Example JSON for POST Request**
```json
[
    {
        "SiteId": "site123",
        "Name": "Load A",
        "Type": "Lighting"
    },
    {
        "SiteId": "site123",
        "Name": "Load B",
        "Type": "HVAC"
    }
]
```
**Response**
```json
[
    {
        "SiteId": "site123",
        "LoadId": "<Generated GUID>",
        "Name": "Load A",
        "Type": "Lighting"
    },
    {
        "SiteId": "site123",
        "LoadId": "<Generated GUID>",
        "Name": "Load B",
        "Type": "HVAC"
    }
]
```
---

###### PUT: Update an Existing Load
- **URL:** `api/DSRIPLoads`
- **Method:** PUT
- **Authorization:** Required

**Request Body:**
- Load object to be updated.

**Behavior:**
- Updates the load if it exists.
- Returns the updated load object.

---

###### DELETE: Delete a Load
- **URL:** `api/DSRIPLoads`
- **Method:** DELETE
- **Authorization:** Required

**Query Parameter:**
- `loadId` (required): ID of the load to be deleted.

**Behavior:**
- Deletes the specified load.
- Returns the deleted load object.

---

##### Loads Data Model

###### Properties:
- `SiteId`: Identifier of the site associated with the load.
- `LoadId`: Unique identifier for the load.
- `Name`: Name of the load.
- `Type`: Type or category of the load.

---

#### 🔋 PowerReading API and Data Model Documentation

##### 📦 PowerReading Data Model

Represents a reading at a particular timestamp for a load associated with a site.

###### 🔸 Field Definitions

| Field Name       | Type    | Description                                |
| -----------------| ------- | ------------------------------------------ |
| powerReadingId   | string  | Unique ID of the power reading             |
| loadId           | string  | Associated Load ID             |
| siteId           | string  | Site ID                                    |
| time             | string  | Timestamp of the reading                   |
| average          | decimal | Average power in the time                  |

---

##### 🔌 PowerReading API Documentation

**Base Route:** `/api/DSRIPPowerReadings`

###### 📥 GET `/api/DSRIPPowerReadings`

**Description:**  
Retrieve power readings for a specific load within a specified time range.

**Query Parameters:**

| Parameter  | Required  | Description                                                  | 
|------------|-----------|--------------------------------------------------------------|
| `loadId`   | Yes       | The ID of the load                                           |
| `startTime`| Yes       | The starting timestamp in yyyy-mm-dd hh:mm:ss format         |
| `endTime`  | Yes       | The starting timestamp in yyyy-mm-dd hh:mm:ss format         |

**Response**
```json
[
  {
    "powerReadingId": "string",
    "loadId": "string",
    "siteId": "string",
    "time": "string",
    "average": 0.0
  },
  {
    "powerReadingId": "string",
    "loadId": "string",
    "siteId": "string",
    "time": "string",
    "average": 0.0
  }
]    
```

###### 🛠️ POST `/api/DSRIPowerReadings`

**Description:**
Create new power reading records.

**Request Body Example:**
```json
[
  {
    "loadId": "string",
    "siteId": "string",
    "time": "string",
    "average": 0.0
  },
  {
    "loadId": "string",
    "siteId": "string",
    "time": "string",
    "average": 0.0
  }
]
```

**Response:**
`201 Created` (Successful insertion)

```json
[
  {
    "powerReadingId": "string",
    "loadId": "string",
    "siteId": "string",
    "time": "string",
    "average": 0.0
  },
  {
    "powerReadingId": "string",
    "loadId": "string",
    "siteId": "string",
    "time": "string",
    "average": 0.0
  }
]
```

###### ✏️ PUT `/api/DSRIPPowerReadings`

**Description:**
Updates an existing PowerReading identified by query parameter `{id}`.

**Query Parameters:**

| Parameter  | Required | Description                                                  | 
|------------|----------|--------------------------------------------------------------|
| `id`       | Yes      | The unique ID of the Power reading to be updated             |

```http
PUT /api/DSRIPPowerReading?id={powerReadingId}
```

**Request Example:**
```json
  {
    "powerReadingId": "string",
    "loadId": "string",
    "siteId": "string",
    "time": "string",
    "average": 0.0
  }
```
**Response**
`204 No Content` (Successful Update) 
`400 Bad Request` (ID mismatch between query and body)
`404 Not Found` (ID not found)

###### ❌ DELETE `/api/DSRIPPowerReadings`
**Description:**
Deletes a power reading identified by query parameter `id`.

**Query Parameters:**

| Parameter  | Required | Description                                                  | 
|------------|----------|--------------------------------------------------------------|
| `id`       | Yes      | The unique ID of the EV reading to be deleted                |

```http
DELETE /api/DSRIPPowerReading?id={powerReadingId}
```

**Response:**
`200 Ok` (Deletion Successful)
`404 Not Found` (powerReadingId in query not found in database)

#### DSRIPPricingSignals API and Data Model Documentation

##### Overview

This API controller manages CRUD operations for `PricingSignals` entities in the DSRIP database.

---

##### API Endpoints

###### GET `/api/DSRIPPricingSignals`

Retrieve pricing signals filtered by date range and optionally by market context.

**Query Parameters:**

- `startDate` (string, required) — Start date in format `YYYY-MM-DD`.
- `endDate` (string, required) — End date in format `YYYY-MM-DD`.
- `marketContext` (string, optional) — Filter by market context substring.

**Responses:**

- `200 OK` — Returns a list of `PricingSignals`.
- `404 Not Found` — If `startDate` or `endDate` are not provided, or no records found.

---

###### PUT `/api/DSRIPPricingSignals`

Update an existing `PricingSignals` record.

**Request Body:**

- A single `PricingSignals` object with an existing `PricingSignalId`.

**Responses:**

- `200 OK` — Returns the updated `PricingSignals` object.

---

###### POST `/api/DSRIPPricingSignals`

Add multiple new `PricingSignals` records.

**Request Body:**

- List of `PricingSignals` objects to add. `PricingSignalId` will be autogenerated.

**Responses:**

- `201 Created` — Returns the last created `PricingSignals` object with its generated `PricingSignalId`.

---

###### DELETE `/api/DSRIPPricingSignals`

Delete a `PricingSignals` record by ID.

**Query Parameter:**

- `id` (string, required) — ID of the `PricingSignals` record to delete.

**Responses:**

- `200 OK` — Returns the deleted `PricingSignals` object.
- `404 Not Found` — If no record found with the given ID.

---

##### Data Model: PricingSignals
The `PricingSignals` data model closely mimics the openADR2.0B eiEvent data schema and is a subset of this specific to interval pricing signals (e.g., hourly pricing signals).

| Property               | Type   | Description                           |
|------------------------|--------|-------------------------------------|
| PricingSignalId        | string | Unique identifier for the signal    |
| EventId                | string | Associated event ID                  |
| Time                   | string | Timestamp of the signal              |
| MarketContext          | string | Market context                      |
| CreatedDateTime        | string | Record creation timestamp            |
| DtStart                | string | Start datetime                      |
| Duration               | string | Duration of the signal               |
| StartAfter             | string | Delay before signal start            |
| SignalValue            | float  | Value of the pricing signal          |
| SignalIntervalText     | string | Text description of signal interval  |
| SignalIntervalStartDate| string | Interval start date                 |
| SignalIntervalDuration | string | Interval duration                   |
| SignalIntervalPayloadValue | float  | Payload value associated with interval |
| SignalDescriptionNumber| int    | Numeric description code            |
| SignalUnitsNumber      | string | Units code                         |
| SignalScaleCode        | int    | Scale code                        |
| SignalId               | string | Signal identifier                   |
| SignalName             | string | Name of the signal                  |
| SignalType             | int    | Type code of the signal             |

---

#### Sites API and Data Model Documentation

##### Overview
The Sites API provides access to site-related data. It supports CRUD (Create, Read, Update, Delete) operations on load entities via RESTful endpoints.

---

##### API Endpoints

###### GET: Retrieve Sites(s)
- **URL:** `api/DSRIPSites`
- **Method:** GET
- **Authorization:** Required

**Query Parameters:**
- `siteId` (optional): ID of the site to retrieve loads for.


**Behavior:**
- If `siteId` is provided, returns all details associated with the site.
- If `siteId` is not provided, returns limited details on all sites.

**Example Response to GET:**
```http
GET /api/DSRIPSites?siteId={optional siteId}
```

```json
  {
    "siteId": "string",
    "utilityId": "string",
    "name": "string",
    "city": "string",
    "state": "string",
    "zipCode": "string",
    "timezone": "string",
    "hasSolar": "string",
    "sqFootage": 0,
    "type": "string",
    "floors": 0,
    "year": 0,
    "occupants": 0,
    "marketContext": "string"
  }
```
---

###### POST: Create New Sites
- **URL:** `api/DSRIPSites`
- **Method:** POST
- **Authorization:** Required

**Request Body:**
- List of Sites objects to be created.

**Behavior:**
- Generates a unique `SiteId` for each new Site.
- Adds all new Sites to the database.

**Response:**
- Returns the created Sites with HTTP `201 Created` status.

**Example JSON for POST Request**
```json
[
  {
    "utilityId": "string",
    "name": "string",
    "city": "string",
    "state": "string",
    "zipCode": "string",
    "timezone": "string",
    "sqFootage": 0,
    "occupants": 0,
    "marketContext": "string"
  }
]
```
**Response**
```json
[
   {
    "siteId": "<Generated GUID>",
    "utilityId": "string",
    "name": "string",
    "city": "string",
    "state": "string",
    "zipCode": "string",
    "timezone": "string",
    "hasSolar": "",
    "sqFootage": 0,
    "type": "",
    "floors": 0,
    "year": 0,
    "occupants": 0,
    "marketContext": "string"
  }
]
```
---

###### PUT: Update an Existing Load
- **URL:** `api/DSRIPSites`
- **Method:** PUT
- **Authorization:** Required

**Request Body:**
- Site object to be updated.

**Behavior:**
- Updates the Site if it exists.
- Returns the updated Site object.

---

###### DELETE: Delete a Load
- **URL:** `api/DSRIPSites`
- **Method:** DELETE
- **Authorization:** Required

**Query Parameter:**
- `siteId` (required): ID of the load to be deleted.

**Behavior:**
- Deletes the specified Site.

---

##### Sites Data Model

###### Properties

- `SiteId` (string): A unique identifier for the site. This value is typically a GUID.
- `UtilityId` (string): Identifier for the utility associated with the site.
- `Name` (string): The name of the site.
- `City` (string): The city where the site is located.
- `State` (string): The state where the site is located.
- `ZipCode` (string): The postal ZIP code of the site.
- `TimeZone` (string): The time zone in which the site is located.
- `HasSolar` (string): Indicates whether the site has solar power capabilities (e.g., "Yes" or "No").
- `SqFootage` (int): The total square footage of the site.
- `Type` (string): The type of the site (e.g., Residential, Commercial, Industrial).
- `Floors` (int): The number of floors in the building at the site.
- `Year` (int): The year the site was built.
- `Occupants` (int): The number of occupants typically present at the site.
- `MarketContext` (string): Describes the market context applicable to the site (e.g., a pricing market or operational category).

###### Notes

- The SiteId serves as the primary key for site records.
- Fields such as HasSolar, Type, and MarketContext can be used for filtering or categorizing sites in analytical or operational workflows.

#### SolarPv API and Data Model Documentation

##### SolarPv Data Model

The `SolarPv` entity represents a solar photovoltaic system associated with a site.

###### Attributes

| Field         | Type   | Description                                  |
|---------------|--------|----------------------------------------------|
| SiteId        | string | Unique identifier for the associated site.    |
| SolarPvId     | string | Unique identifier for the solar PV system.    |
| Name          | string | Name of the solar PV system.                  |
| HouseholdId   | string | Household ID for SolarPV in MF buildings      |

---

##### SolarPv API Endpoints

###### Base URL
```text
/api/DSRIPSolarPv
```

---

###### GET: Retrieve SolarPv Records
Retrieve all SolarPv records for a site or a specific SolarPv by ID.

**Request**
```http
GET /api/DSRIPSolarPv?siteId={siteId}&solarpvId={solarpvId}
```

**Query Parameters**
| Parameter   | Required | Description                                  |
|-------------|----------|----------------------------------------------|
| siteId      | Yes      | Identifier for the site.                     |
| solarpvId   | No       | Identifier for a specific SolarPv record.     |

**Responses**
- **200 OK**: Returns list of SolarPv records.
- **404 Not Found**: If siteId and solarpvId are missing.

**Example Response**
```json
[
  {
    "siteId": "site-001",
    "solarPvId": "solar-001",
    "name": "Main Roof Solar",
    "householdId": "house-001"
  }
]
```

---

###### POST: Create SolarPv Records
Create one or more SolarPv records.

**Request**
```http
POST /api/DSRIPSolarPv
```

**Request Body**
```json
[
  {
    "siteId": "site-001",
    "name": "Main Roof Solar",
    "householdId": "house-001"
  }
]
```

**Responses**
- **201 Created**: Returns the created SolarPv record.

```json
[
  {
    "siteId": "site-001",
    "solarPvId": "<Generated GUID>",
    "name": "Main Roof Solar",
    "householdId": "house-001"
  }
]
```

---

###### PUT: Update a SolarPv Record
Update an existing SolarPv record.

**Request**
```http
PUT /api/DSRIPSolarPv
```

**Request Body**
```json
{
  "siteId": "site-001",
  "solarPvId": "solar-001",
  "name": "Updated Solar Name",
  "householdId": "house-001"
}
```

**Responses**
- **200 OK**: Record updated successfully.
- **404 Not Found**: Record not found.

---

###### DELETE: Remove a SolarPv Record
Delete a SolarPv record by ID.

**Request**
```http
DELETE /api/DSRIPSolarPv?id={solarPvId}
```

**Parameters**
| Parameter   | Required | Description                    |
|-------------|----------|--------------------------------|
| id          | Yes      | Identifier for the SolarPv record. |

**Responses**
- **200 OK**: Record deleted successfully.
- **404 Not Found**: Record not found.

---

#### SolarPvReading API and Data Model Documentation

##### API Endpoints

###### GET /api/DSRIPSolarPvReading
**Description:** Retrieve solar PV readings for a specified SolarPvId within a specified time window.

**Query Parameters:**
- `solarPvId` (string, required): Identifier of the Solar PV system.
- `startTime` (string, required): Start of the time range (format: `YYYY-MM-DDTHH:MM:SS`).
- `endTime` (string, required): End of the time range (format: `YYYY-MM-DDTHH:MM:SS`).

**Response Example:**
```json
[
  {
    "solarPvReadingId": "123e4567-e89b-12d3-a456-426614174000",
    "solarPvId": "abc123",
    "siteId": "site001",
    "time": "2024-06-18T15:00:00",
    "energyValue": "500",
    "powerValue": "200",
    "storageValue": "50"
  }
]
```

###### POST /api/DSRIPSolarPvReading
**Description:** Insert new solar PV readings.

**Request Body Example:**
```json
[
  {
    "solarPvId": "abc123",
    "siteId": "site001",
    "time": "2024-06-18T15:00:00",
    "energyValue": "500",
    "energyMeterId": "em001",
    "energyMeterConsumption": "100",
    "energyMeterPurchased": "50",
    "energyMeterProduction": "200",
    "energyMeterSelfConsumption": "100",
    "energyMeterFeedIn": "50",
    "powerValue": "200",
    "powerMeterId": "pm001",
    "powerMeterConsumption": "80",
    "powerMeterPurchased": "30",
    "powerMeterProduction": "150",
    "powerMeterSelfConsumption": "70",
    "powerMeterFeedIn": "20",
    "storageValue": "50",
    "storageMeterId": "sm001",
    "storageMeterConsumption": "10",
    "storageMeterPurchased": "5",
    "storageMeterProduction": "30",
    "storageMeterSelfConsumption": "15",
    "storageMeterFeedIn": "5"
  }
]
```

**Response:**
```json
{
  "solarPvReadingId": "123e4567-e89b-12d3-a456-426614174000",
  "solarPvId": "abc123",
  "siteId": "site001",
  "time": "2024-06-18T15:00:00",
  "energyValue": "500",
  "powerValue": "200",
  "storageValue": "50"
}
```

###### PUT /api/DSRIPSolarPvReading
**Description:** Update an existing solar PV reading.

**Request Body Example:**
```json
{
  "solarPvReadingId": "123e4567-e89b-12d3-a456-426614174000",
  "solarPvId": "abc123",
  "siteId": "site001",
  "time": "2024-06-18T15:00:00",
  "energyValue": "550",
  "powerValue": "210",
  "storageValue": "60"
}
```

**Response:**
HTTP 204 No Content

###### DELETE /api/DSRIPSolarPvReading
**Description:** Delete a solar PV reading by ID.

**Query Parameter:**
- `id` (string, required): Identifier of the solar PV reading to delete.

**Response Example:**
```json
{
  "solarPvReadingId": "123e4567-e89b-12d3-a456-426614174000",
  "solarPvId": "abc123",
  "siteId": "site001",
  "time": "2024-06-18T15:00:00",
  "energyValue": "500",
  "powerValue": "200",
  "storageValue": "50"
}
```

---

##### SolarPvReading Data Model

| Attribute                  | Type   | Description                         |
|---------------------------|--------|-------------------------------------|
| solarPvReadingId          | string | Unique identifier for the reading   |
| solarPvId                 | string | ID of the associated Solar PV unit  |
| siteId                    | string | ID of the site                      |
| time                      | string | Timestamp of the reading            |
| energyValue               | string | Total energy value                  |
| energyMeterId             | string | ID of the energy meter              |
| energyMeterConsumption    | string | Energy consumed                     |
| energyMeterPurchased      | string | Energy purchased                    |
| energyMeterProduction     | string | Energy produced                     |
| energyMeterSelfConsumption| string | Self-consumed energy                |
| energyMeterFeedIn         | string | Energy fed back to the grid         |
| powerValue                | string | Total power value                   |
| powerMeterId              | string | ID of the power meter               |
| powerMeterConsumption     | string | Power consumed                      |
| powerMeterPurchased       | string | Power purchased                     |
| powerMeterProduction      | string | Power produced                      |
| powerMeterSelfConsumption | string | Self-consumed power                 |
| powerMeterFeedIn          | string | Power fed back to the grid          |
| storageValue              | string | Total storage value                 |
| storageMeterId            | string | ID of the storage meter             |
| storageMeterConsumption   | string | Storage consumption                 |
| storageMeterPurchased     | string | Storage purchased                   |
| storageMeterProduction    | string | Storage produced                    |
| storageMeterSelfConsumption| string | Self-consumed storage               |
| storageMeterFeedIn        | string | Storage fed back to the grid        |

---

#### Thermostat API Documentation

##### Thermostat Data Model
| Attribute    | Type   | Description                          |
| ------------ | ------ | ------------------------------------ |
| siteId       | string | Identifier of the associated site    |
| thermostatId | string | Unique identifier for the thermostat |
| name         | string | Thermostat name                      |
| endUse       | string | End use category (e.g., HVAC)        |


##### API Endpoints

###### GET /api/DSRIPThermostat
Retrieve thermostats for a given site or a specific thermostat by ID.

**Query Parameters:**
- `siteId` (string, optional): Site ID to retrieve all thermostats associated with the site.
- `thermostatId` (string, optional): Thermostat ID to retrieve a specific thermostat.

**Responses:**
- `200 OK`: Returns the list of matching thermostats.
- `404 Not Found`: If both `siteId` and `thermostatId` are null.

**Example Response:**
```json
[
  {
    "siteId": "site001",
    "thermostatId": "tstat001",
    "name": "Living Room Thermostat",
    "endUse": "HVAC"
  }
]
```

###### POST /api/DSRIPThermostat
Create one or more new thermostat records.

**Request Body**
Array of thermostat objects

**Example Request:**
```json
[
  {
    "siteId": "site001",
    "name": "Living Room Thermostat",
    "endUse": "HVAC"
  }
]
```
**Response**
- `201 Created`: Returns the created thermostat(s).

```json
[
  {
    "siteId": "site001",
    "thermostatId": "<generated-guid>",
    "name": "Living Room Thermostat",
    "endUse": "HVAC"
  }
]
```
###### PUT /api/DSRIPThermostat
Update an existing thermostat record.

**Request Body:**
Thermostat object to update.

**Example Request:**
```json
{
  "siteId": "site001",
  "thermostatId": "tstat001",
  "name": "Updated Thermostat Name",
  "endUse": "HVAC"
}
```
**Response**
- `200 Ok`: Returns the updated thermostat

###### DELETE /api/DSRIPThermostat
Delete a thermostat by ID.

**Query Parameters**
- `id` (string, required): ID of thermostat to be deleted

**Responses**
- `200 OK`: Returns the deleted thermostat.
- `404 Not Found`: If the thermostat does not exist.

#### ThermostatReading API and Data Model Documentation 

##### Data Model: ThermostatReading

| Attribute           | Type   | Description                         |
|---------------------|--------|-------------------------------------|
| ThermostatReadingId | string | Unique identifier for the reading   |
| ThermostatId        | string | ID of the associated thermostat     |
| SiteId              | string | ID of the site                      |
| Time                | string | Timestamp of the reading            |
| CoolSetting         | int    | Cool temperature setpoint           |
| HeatSetting         | int    | Heat temperature setpoint           |
| Fan                 | string | Fan mode (e.g., on, off, auto)      |
| Temperature         | string | Current measured temperature        |
| RunStatus           | string | Current operational status          |
| System              | string | System mode (e.g., heat, cool, off) |

---

##### API Endpoints

###### GET /api/DSRIPThermostatReading
**Description:** Retrieve thermostat readings for a specified thermostat ID within a specified time window.

**Query Parameters:**
- `thermostatId` (string, required): Identifier of the thermostat.
- `startTime` (string, required): Start of the time range (format: `YYYY-MM-DDTHH:MM:SS`).
- `endTime` (string, required): End of the time range (format: `YYYY-MM-DDTHH:MM:SS`).

**Response Example:**
```json
[
  {
    "thermostatReadingId": "123e4567-e89b-12d3-a456-426614174000",
    "thermostatId": "thermo001",
    "siteId": "site001",
    "time": "2024-06-18T15:00:00",
    "coolSetting": 72,
    "heatSetting": 68,
    "fan": "Auto",
    "temperature": "70",
    "runStatus": "Running",
    "system": "Cooling"
  }
]
```

###### POST /api/DSRIPThermostatReading
**Description:** Insert new thermostat readings.

**Request Body Example:**
```json
[
  {
    "thermostatId": "thermo001",
    "siteId": "site001",
    "time": "2024-06-18T15:00:00",
    "coolSetting": 72,
    "heatSetting": 68,
    "fan": "Auto",
    "temperature": "70",
    "runStatus": "Running",
    "system": "Cooling"
  }
]
```

**Response Example:**
```json
{
  "thermostatReadingId": "123e4567-e89b-12d3-a456-426614174000",
  "thermostatId": "thermo001",
  "siteId": "site001",
  "time": "2024-06-18T15:00:00",
  "coolSetting": 72,
  "heatSetting": 68,
  "fan": "Auto",
  "temperature": "70",
  "runStatus": "Running",
  "system": "Cooling"
}
```

###### PUT /api/DSRIPThermostatReading
**Description:** Update an existing thermostat reading.

**Request Body Example:**
```json
{
  "thermostatReadingId": "123e4567-e89b-12d3-a456-426614174000",
  "thermostatId": "thermo001",
  "siteId": "site001",
  "time": "2024-06-18T15:00:00",
  "coolSetting": 74,
  "heatSetting": 66,
  "fan": "On",
  "temperature": "71",
  "runStatus": "Idle",
  "system": "Heating"
}
```

**Response:**
HTTP 204 No Content

###### DELETE /api/DSRIPThermostatReading
**Description:** Delete a thermostat reading by ID.

**Query Parameter:**
- `id` (string, required): Identifier of the thermostat reading to delete.

**Response Example:**
```json
{
  "thermostatReadingId": "123e4567-e89b-12d3-a456-426614174000",
  "thermostatId": "thermo001",
  "siteId": "site001",
  "time": "2024-06-18T15:00:00",
  "coolSetting": 72,
  "heatSetting": 68,
  "fan": "Auto",
  "temperature": "70",
  "runStatus": "Running",
  "system": "Cooling"
}
```
---

#### Utilities Data Model and API Documentation

##### Data Model: Utilities

| Attribute    | Type   | Description                         |
|--------------|--------|-------------------------------------|
| UtilityId    | string | Unique identifier for the utility   |
| UtilityName  | string | Name of the utility provider        |

###### Description

The `Utilities` data model represents utility providers within the system. Each utility is uniquely identified by a `UtilityId` and has a corresponding `UtilityName`. This model is typically used to link sites, pricing, and other energy assets to their respective utility providers.

##### API Documentation 

###### GET: Retrieve All Utilities

**Endpoint:** `GET /api/DSRIPUtilities`

**Description:**
Fetches a list of all utilities available in the system.

**Response:**
- 200 OK: Returns a list of all utilities.

---

###### GET: Retrieve Utility by ID

**Endpoint:** `GET /api/DSRIPUtilities/{id}`

**Parameters:**
- `id` (string): Unique identifier of the utility.

**Description:**
Fetches a specific utility based on the provided Utility ID.

**Response:**
- 200 OK: Returns the utility object.
- 404 Not Found: If the utility with the provided ID does not exist.

---

###### PUT: Update Utility by ID

**Endpoint:** `PUT /api/DSRIPUtilities/{id}`

**Parameters:**
- `id` (string): Unique identifier of the utility.

**Body:**
- `Utilities` object with updated information.

**Description:**
Updates the utility identified by the provided ID.

**Response:**
- 204 No Content: Successfully updated.
- 400 Bad Request: If the ID in the URL does not match the ID in the body.
- 404 Not Found: If the utility with the provided ID does not exist.

---

###### POST: Create New Utility

**Endpoint:** `POST /api/DSRIPUtilities`

**Body:**
- `Utilities` object with utility details.

**Description:**
Creates a new utility record.

**Response:**
- 201 Created: Returns the created utility object.

---

###### DELETE: Delete Utility by ID

**Endpoint:** `DELETE /api/DSRIPUtilities/{id}`

**Parameters:**
- `id` (string): Unique identifier of the utility.

**Description:**
Deletes the utility record identified by the provided ID.

**Response:**
- 200 OK: Returns the deleted utility object.
- 404 Not Found: If the utility with the provided ID does not exist.

---

#### WaterHeater Data Model and API Documentation

##### Data Model: WaterHeater

| Attribute       | Type   | Description                          |
|-----------------|--------|--------------------------------------|
| SiteId          | string | Identifier for the associated site   |
| WaterHeaterId   | string | Unique identifier for the water heater |
| Name            | string | Name or label for the water heater    |
| EndUse          | string | Description of the end use            |

###### Description

The `WaterHeater` data model represents water heaters within a site. Each water heater has a unique identifier (`WaterHeaterId`), is linked to a specific site via `SiteId`, and includes descriptive fields such as `Name` and `EndUse` to clarify its role and function in the system.

##### API: DSRIPWaterHeaterController

Base Route: `/api/DSRIPWaterHeater`

###### Authorization

- All endpoints require authorization `[Authorize]` attribute.

---

###### GET /api/DSRIPWaterHeater?siteId={siteId}&waterheaterId={waterheaterId}

- **Description:** Retrieves water heater(s) filtered by siteId and/or waterheaterId.
- **Parameters:**
  - `siteId` (string, optional): Site identifier.
  - `waterheaterId` (string, optional): Water heater identifier.
- **Returns:**  
  - List of `WaterHeater` objects if `waterheaterId` is null and `siteId` is provided.
  - Single or list of water heaters matching `waterheaterId` if specified.
- **Responses:**
  - `200 OK` with water heater data.
  - `404 Not Found` if no matching water heaters found or both parameters null.

- **Example Response**
```json
[
  {
	"siteId": "ed6c7185-a11d-4754-8e86-d481cf209f29",
    "waterHeaterId": "39032da2-da24-48f6-bba2-8a0dd14f18e4",
	"name": "Unit 116",
	"type": "Rheem EcoNet Gen 4"
  }
]
```
---

###### PUT /api/DSRIPWaterHeater

- **Description:** Updates an existing water heater record.
- **Body:**  
  - JSON representation of a `WaterHeater` object.
- **Returns:**  
  - The updated `WaterHeater` object.
- **Responses:**
  - `204 No Content` on successful update.
  - `404 Not Found` if water heater does not exist.
  - Throws `DbUpdateConcurrencyException` if concurrency conflict occurs.

---

###### POST /api/DSRIPWaterHeater

- **Description:** Adds one or more new water heater records.
- **Body:**  
  - JSON array of `WaterHeater` objects.
- **Example Request**
```json
[
  {
	"siteId": "ed6c7185-a11d-4754-8e86-d481cf209f29",
    "name": "Unit 116",
	"type": "Rheem EcoNet Gen 4"
  }
]
```
- **Returns:**  
  - The last created `WaterHeater` object(s).
- **Example Responses**
```json
[
  {
	"siteId": "ed6c7185-a11d-4754-8e86-d481cf209f29",
    "waterHeaterId": "39032da2-da24-48f6-bba2-8a0dd14f18e4",
	"name": "Unit 116",
	"type": "Rheem EcoNet Gen 4"
  }
]
```
- **Notes:**  
  - Each new water heater is assigned a new GUID for `WaterHeaterId`.
- **Responses:**
  - `201 Created` with location header to retrieve the created resource.

---

###### DELETE /api/DSRIPWaterHeater?id={id}

- **Description:** Deletes a water heater by its ID.
- **Parameters:**
  - `id` (string): Identifier of the water heater to delete.
- **Returns:**  
  - The deleted `WaterHeater` object.
- **Responses:**
  - `200 OK` with deleted water heater.
  - `404 Not Found` if water heater does not exist.

---

#### WaterHeaterReading Data Model and API Documentation

##### Data Model: WaterHeaterReading

| Attribute            | Type   | Description                                    |
|----------------------|--------|------------------------------------------------|
| WaterHeaterReadingId | string | Unique identifier for the water heater reading |
| SiteId               | string | Identifier for the associated site             |
| WaterHeaterId        | string | Identifier for the associated water heater     |
| Time                 | string | Timestamp of the reading                      |
| Status               | int    | Operational status of the water heater         |
| SetPoint             | int    | Current temperature setpoint                  |
| MinSetPoint          | int    | Minimum allowable setpoint                    |
| MaxSetPoint          | int    | Maximum allowable setpoint                    |
| UpperTemperature     | int    | Temperature reading from the upper sensor     |
| LowerTemperature     | int    | Temperature reading from the lower sensor     |
| AmbientTemperature   | int    | Ambient temperature around the water heater   |
| TemperatureUnits     | string | Units of the temperature measurement          |
| VacationMode         | string | Indicates if vacation mode is active          |
| InUse                | string | Indicates if the water heater is currently in use |

##### Description

The `WaterHeaterReading` data model captures detailed operational data for water heaters at specific points in time. It includes status, temperature readings, setpoints, and operational modes. This model is essential for monitoring, analytics, and control of water heating systems within energy management platforms.

##### API: DSRIPWaterHeaterReadingController

###### GET: Retrieve Water Heater Readings
```
GET /api/DSRIPWaterHeaterReading?waterheaterId={waterheaterId}&startTime={startTime}&endTime={endTime}
```
- **Description:** Retrieves water heater readings for a specific water heater within a given time range.
- **Query Parameters:**
  - `waterheaterId` (string) - Required
  - `startTime` (string) - Required (ISO 8601 format)
  - `endTime` (string) - Required (ISO 8601 format)
- **Responses:**
  - `200 OK` - Returns a list of `WaterHeaterReading` objects.
  - `404 Not Found` - Missing or invalid parameters.
  - **Example Response**
```json
[
  {
	"siteid": "ed6c7185-a11d-4754-8e86-d481cf209f29",
	"waterheaterid": "3c7c6ade-e478-4b8b-9686-b5c054039c20",
    "waterheaterreadingid": "903b4808-5f8d-46d5-84c9-819c8200474f",
	"time": "2020-12-31 00:00:00",
	"setpoint": 120,
	"maxsetpoint": 140,
	"minsetpoint": 110,
	"ambienttemperature": 45,
	"uppertemperature": 138,
	"lowertemperature": 129
  },
  {
	"siteid": "ed6c7185-a11d-4754-8e86-d481cf209f29",
	"waterheaterid": "3c7c6ade-e478-4b8b-9686-b5c054039c20",
    "waterheaterreadingid": "582c415a-decc-48c8-8b6c-872f9131fb36",
	"time": "2020-12-31 00:05:00",
	"setpoint": 120,
	"maxsetpoint": 140,
	"minsetpoint": 110,
	"ambienttemperature": 43,
	"uppertemperature": 137,
	"lowertemperature": 127
  }
]
```
###### PUT: Update Water Heater Reading
```
PUT /api/DSRIPWaterHeaterReading
```
- **Description:** Updates an existing water heater reading.
- **Request Body:** `WaterHeaterReading` object
- **Responses:**
  - `200 OK` - Returns the updated `WaterHeaterReading` object.
  - `404 Not Found` - If the reading does not exist.

###### POST: Create Water Heater Readings
```
POST /api/DSRIPWaterHeaterReading
```
- **Description:** Creates new water heater readings.
- **Request Body:** Array of `WaterHeaterReading` objects
- **Example Request**
```json
[
  {
	"siteid": "ed6c7185-a11d-4754-8e86-d481cf209f29",
	"waterheaterid": "3c7c6ade-e478-4b8b-9686-b5c054039c20",
	"time": "2020-12-31 00:00:00",
	"setpoint": 120,
	"maxsetpoint": 140,
	"minsetpoint": 110,
	"ambienttemperature": 45,
	"uppertemperature": 138,
	"lowertemperature": 129
  },
  {
	"siteid": "ed6c7185-a11d-4754-8e86-d481cf209f29",
	"waterheaterid": "3c7c6ade-e478-4b8b-9686-b5c054039c20",
	"time": "2020-12-31 00:05:00",
	"setpoint": 120,
	"maxsetpoint": 140,
	"minsetpoint": 110,
	"ambienttemperature": 43,
	"uppertemperature": 137,
	"lowertemperature": 127
  }
]
```
- **Responses:**
  - `201 Created` - Returns the last created `WaterHeaterReading` object.

###### DELETE: Delete Water Heater Reading
```
DELETE /api/DSRIPWaterHeaterReading?id={id}
```
- **Description:** Deletes a water heater reading by ID.
- **Query Parameter:**
  - `id` (string) - Required
- **Responses:**
  - `200 OK` - Returns the deleted `WaterHeaterReading` object.
  - `404 Not Found` - If the reading does not exist.

---

## Testing

The `openDSRIP` repository provides a dedicated `test` folder that contains sample data files which can be used to validate the functionality of the API endpoints, particularly the POST operations.

### Repository Link:
[https://github.com/eprissankara73/openDSRIP](https://github.com/eprissankara73/openDSRIP)

### How to Test:
1. Clone or download the `openDSRIP` repository.
2. Setup a database using the `dsrip-ppd.sql` file to setup tables
3. Navigate to the `test` folder within the repository.
4. The sample data files in this folder can be used to:
   - Validate successful creation of records via POST endpoints.
   - Simulate real-world data ingestion for each data model.
   - Test response handling for authorized endpoints.

### Purpose:
- To verify that a newly deployed `openDSRIP` application correctly handles and persists the sample data provided.
- To ensure data model integrity and endpoint accessibility.

### Notes:
- Make sure the application is properly authenticated if the endpoints are protected by authorization.
- Review the structure of each JSON sample to match the expected payloads for the corresponding API.

---

## License

The `openDSRIP` application is an open-source project licensed under the **MIT License**.

### License Terms:
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

- The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

### Disclaimer:
The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.

### Summary:
- ✅ Free for personal and commercial use  
- ✅ Modifications and redistribution allowed  
- ✅ Attribution required  
- ❌ No warranty provided

For full license text, refer to the `LICENSE` file in the `openDSRIP` repository.

---

## Credits & Acknowledgements

### Author Credits  
Electric Power Research Institute (EPRI)  
3420 Hillview Avenue  
Palo Alto, CA 94304

---

### Acknowledgements  
Special thanks to the **California Energy Commission (CEC)** for funding the development of the `openDSRIP` application under **Grant EPC-15-075**.

The full project report is publicly accessible here:  
[https://www.energy.ca.gov/sites/default/files/2024-06/CEC-500-2024-079.pdf](https://www.energy.ca.gov/sites/default/files/2024-06/CEC-500-2024-079.pdf)

The authors gratefully acknowledges the support provided by CEC which made this work possible.
