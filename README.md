# SensorAPI
Release version 0.2.0 - Finished basic application and deployed to production ennviornment. 


# PROJECT REVISION: 0.2.0
Current data logger does not allow any API access, but an exposed sensor1.wdf file contains the data required for this project.
API features will be added in future revisions, but for now the data can be accessed by reading the wdf file directly.

	1. Obsoleting FetchWeather.cs and GetJSON.cs for now.
	2. Adding FetchData.cs for reading the wdf file and parsing the data into usable formats for the excel.
	3. obsoleted all classes except dewpointcalculator. New program.cs needs refactoring in the future.

# Generic API for Wifi capable sensors.
REMOVED THIS FEATURE. CURRENT PROD ENVIORNMENT DOES NOT SUPPORT WIFI CONNECTIVITY. FUTURE REVISIONS MAY ADD THIS FEATURE BACK IN.

Built in Alert system for critical temp, humidity, and dew point.

Built in File output and logging system.
 
	To Do: Add Wifi connectivity and data transmission over local network. Internet is not a planned feature.
	To Do: Finish alarm system with automailer and text message alerts.
	To Do: Clean up classes and method structure with getters and setters and reassess public vs private access modifiers.

Bonus To Do: fully implement a GUI for the system with real time data display, event logging and marking, and alarm management.
 
# Structure:
Program.cs: Main program loop, handles sensor data collection, file output.

DewPointCalculator.cs: Class and method for calculating dew point based on temperature and humidity.

