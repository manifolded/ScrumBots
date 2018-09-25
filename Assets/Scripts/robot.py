import sys
sys.path.append('Assets/Scripts')
sys.path.append('Assets/Plugins/Resources/Lib')
import json

motorLeft = 0.6
motorRight = -0.3

commandDict = {
    "motorLeft": motorLeft,
    "motorRight": motorRight
}

# The "commands" variable will be fetched by the calling script.  Values set here will act as commands to
# control the robot.
commands = json.dumps(commandDict)
