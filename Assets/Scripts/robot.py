import sys
sys.path.append('Assets/Scripts')
sys.path.append('Assets/Plugins/Resources/Lib')
import json

# maxTorque will be inserted in to the scope by the C# wrapper

leftTorque = 0.6*maxTorque
rightTorque = -0.6*maxTorque

commandDict = {
    "leftTorque": leftTorque,
    "rightTorque": rightTorque
}

# The "commands" variable will be fetched by the calling script.  Values set here will act as commands to
# control the robot.
commands = json.dumps(commandDict)
