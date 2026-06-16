# SensorAPI

# PROJECT REVISION: 0.1.0
Current data logger does not allow any API access, but an exposed sensor1.wdf file contains the data required for this project.
API features will be added in future revisions, but for now the data can be accessed by reading the wdf file directly.
	1. Obesoleting FetchWeather.cs and GetJSON.cs for now.
	2. Adding FetchData.cs for reading the wdf file and parsing the data into usable formats for the excel.
	

# Generic API for Wifi capable sensors.
Built in Alert system for critical temp, humidity, and dew point.

Built in File output and logging system.
 
To Do: Add Wifi connectivity and data transmission over local network. Internet is not a planned feature.

To Do: Finish alarm system with automailer and text message alerts.

To Do: Clean up classes and method structure with getters and setters and reassess public vs private access modifiers.

Bonus To Do: fully implement a GUI for the system with real time data display, event logging and marking, and alarm management.
 
# Structure:
Program.cs: Main program loop, handles sensor data collection, file output, and alarm checking.

DewPointCalculator.cs: Static class for calculating dew point based on temperature and humidity.

OutputToFile.cs: Static class for handling file output, including creating new files and appending data. 

Pause.cs: Static class for handling program pauses, possibly obsolete. Only necessary when reunning consoleapp and need to exit gracefully. May be removed in favor of a more robust solution for handling program termination and restarts with GUI.

Alert.cs: Static class for handling alert conditions and triggering alerts when thresholds are exceeded.

# TO BE OBSOLETED
FetchWeather.cs: Static class for fetching weather data from an online API, used for comparison and alerting.