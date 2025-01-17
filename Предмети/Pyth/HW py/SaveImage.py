import json
import base64
from datetime import datetime

# Read the image file as binary
with open('12.jpg', 'rb') as image_file:
    # Encode the binary data in Base64
    encoded_image = base64.b64encode(image_file.read()).decode('utf-8')

# Create a dictionary with image metadata and encoded data
image_data = {
    'filename': '12.jpg',
    'width': 800,
    'height': 600,
    'data': encoded_image
}

# Generate a unique filename using timestamp
timestamp = datetime.now().strftime('%Y%m%d%H%M%S')
json_filename = f'image_data_{timestamp}.json'

# Convert the dictionary to JSON
json_data = json.dumps(image_data, indent=2)

# Save the JSON data to the file with the unique filename
with open(json_filename, 'w') as json_file:
    json_file.write(json_data)

