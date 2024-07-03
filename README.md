# PlataformaAED
 
Proyect:

    A RESTful API must be developed in C# with layered separation and design patterns, utilizing a relational MySQL database to support the described functionalities. Tables, stored procedures, functions, etc., must be created accordingly.

Functional Requirements:

    -Retrieve current reservations for a sports area.
    -Add a new reservation.
    -Modify an existing reservation.
    -Delete a reservation per day.
    -Creation of Sports Area:
    -Modify details of a sports area.
    -Delete a sports area.

## Content Table
1. [Endpoint Documentation](#EndpointDocumentation)
2. [Database Scripts](#DatabaseScripts)
3. [Installation and Configuration Instructions](#InstallationandConfigurationInstructions)

## EndpointDocumentation

Documentation:
  {
    "openapi": "3.0.1",
    "info": {
      "title": "PlataformaAED",
      "version": "1.0"
    },
    "paths": {
      "/api/Reserv": {
        "get": {
          "tags": [
            "Reserv"
          ],
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        },
        "post": {
          "tags": [
            "Reserv"
          ],
          "requestBody": {
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/Reserv"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/Reserv"
                }
              },
              "application/*+json": {
                "schema": {
                  "$ref": "#/components/schemas/Reserv"
                }
              }
            }
          },
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        },
        "put": {
          "tags": [
            "Reserv"
          ],
          "requestBody": {
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/Reserv"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/Reserv"
                }
              },
              "application/*+json": {
                "schema": {
                  "$ref": "#/components/schemas/Reserv"
                }
              }
            }
          },
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        },
        "delete": {
          "tags": [
            "Reserv"
          ],
          "parameters": [
            {
              "name": "id",
              "in": "query",
              "schema": {
                "type": "integer",
                "format": "int32"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        }
      },
      "/api/Reserv/id": {
        "get": {
          "tags": [
            "Reserv"
          ],
          "parameters": [
            {
              "name": "id",
              "in": "query",
              "schema": {
                "type": "integer",
                "format": "int32"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        }
      },
      "/api/SportArea": {
        "get": {
          "tags": [
            "SportArea"
          ],
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        },
        "post": {
          "tags": [
            "SportArea"
          ],
          "requestBody": {
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/SportArea"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/SportArea"
                }
              },
              "application/*+json": {
                "schema": {
                  "$ref": "#/components/schemas/SportArea"
                }
              }
            }
          },
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        },
        "put": {
          "tags": [
            "SportArea"
          ],
          "requestBody": {
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/SportArea"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/SportArea"
                }
              },
              "application/*+json": {
                "schema": {
                  "$ref": "#/components/schemas/SportArea"
                }
              }
            }
          },
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        },
        "delete": {
          "tags": [
            "SportArea"
          ],
          "parameters": [
            {
              "name": "id",
              "in": "query",
              "schema": {
                "type": "integer",
                "format": "int32"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        }
      },
      "/api/SportArea/id": {
        "get": {
          "tags": [
            "SportArea"
          ],
          "parameters": [
            {
              "name": "id",
              "in": "query",
              "schema": {
                "type": "integer",
                "format": "int32"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success"
            }
          }
        }
      }
    },
    "components": {
      "schemas": {
        "Reserv": {
          "required": [
            "res_customer",
            "res_date",
            "res_name"
          ],
          "type": "object",
          "properties": {
            "res_id": {
              "type": "integer",
              "format": "int32"
            },
            "res_name": {
              "maxLength": 255,
              "minLength": 1,
              "type": "string"
            },
            "res_customer": {
              "maxLength": 255,
              "minLength": 1,
              "type": "string"
            },
            "res_date": {
              "maxLength": 255,
              "minLength": 1,
              "type": "string"
            },
            "res_sportArea": {
              "type": "integer",
              "format": "int32"
            }
          },
          "additionalProperties": false
        },
        "Reservation": {
          "type": "object",
          "properties": {
            "res_id": {
              "type": "integer",
              "format": "int32"
            },
            "res_name": {
              "type": "string",
              "nullable": true
            },
            "res_location": {
              "type": "string",
              "nullable": true
            },
            "res_date": {
              "type": "string",
              "nullable": true
            },
            "res_customer": {
              "type": "string",
              "nullable": true
            }
          },
          "additionalProperties": false
        },
        "SportArea": {
          "required": [
            "sa_customer_name",
            "sa_location"
          ],
          "type": "object",
          "properties": {
            "sa_id": {
              "type": "integer",
              "format": "int32"
            },
            "sa_location": {
              "maxLength": 255,
              "minLength": 1,
              "type": "string"
            },
            "sa_customer_name": {
              "maxLength": 255,
              "minLength": 1,
              "type": "string"
            }
          },
          "additionalProperties": false
        }
      }
    }
  }



## DatabaseScripts

Database Setup Scripts:

    CREATE SCHEMA `reservationsdb`
    USE `reservationsdb`;

    CREATE TABLE SportAreaTable (
        sa_id INT PRIMARY KEY AUTO_INCREMENT,
        sa_location VARCHAR(255),
        sa_customer_name VARCHAR(255)
    );

    CREATE TABLE ResTable (
        res_id INT PRIMARY KEY AUTO_INCREMENT,
        res_name VARCHAR(255),
        res_customer VARCHAR(255),
        res_date VARCHAR(255),
        res_sportArea INT,
        FOREIGN KEY (res_sportArea) REFERENCES SportAreaTable(sa_id)
    );


  INSERT INTO `sportareatable` VALUES (1,'Plaza 2-C','John Doe'),(3,'Plaza 5-D','James Doe');
  INSERT INTO `restable` VALUES (1,'string','string','string',1),(3,'test','test','test',3);


## InstallationandConfigurationInstructions
Requirements:

    1. Download the .NET installer from https://dotnet.microsoft.com/download/dotnet

    2. Download Visual Studio from https://visualstudio.microsoft.com/

    3. Download the installer for the latest version of MySQL Installer from https://dev.mysql.com/downloads/installer/

    4. Download the installer for the latest version of MySQL WorkBench from https://dev.mysql.com/downloads/workbench/

    5. Download the installer for the latest version of Postman from https://www.postman.com/downloads/


.NET and Visual Studio Setup:

    https://www.youtube.com/watch?v=-X4lzcC6_Sg

MySQL Database Setup:
  login: root
  password: root

  1. https://www.youtube.com/watch?v=u96rVINbAUI


Once everything is installed and the database is configured and running, open the project in Visual Studio and execute it. The project includes an interface called SwaggerUI which allows you to test and make requests to the API, as well as view the schemas.

From Swagger, you can perform all CRUD tests for Reservations and Sport Areas. To enter a new reservation it is necessary to associate it with an existing Sport Area. If that ID does not exist in its respective table the request will not be completed.

In my case I preferred to test all the requests from the POSTMAN platform, which is much more convenient.







