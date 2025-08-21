from PIL import Image, ImageDraw

positions = []

filename = "lamparray.0.csv"
output_filename = "lamparray.0.png"

with open("lamparray.0.csv") as f:
    contents = f.read()

coordinates = []

max_x = 0
max_y = 0
scale = 1000
dot_size = 2
padding = 20

# parse into list of (x, y, z) values
for line in contents.splitlines()[1:]: # ignore header
    x, y, z = line.split(",")
    coordinates.append((float(x), float(y), float(z)))

    max_x = max(max_x, float(x))
    max_y = max(max_y, float(y))

img_x = int(scale * max_x + padding)
img_y = int(scale * max_y + padding)

img = Image.new('RGB', (img_x, img_y), "white")
draw = ImageDraw.Draw(img)

idx = 0
for x, y, z in coordinates:

    x *= scale
    y *= scale
    draw.rectangle(
        (x, y, x + dot_size, y + dot_size), fill="red"
    )
    draw.text((x, y), f"{idx}", fill="black")
    idx += 1

# img.show()
img.save(output_filename)