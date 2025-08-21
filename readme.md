# DynamicLightingCsv

Dumps a CSV of the (X, Y, Z) coordinates for connected Windows Dynamic Lighting devices. This targets `net8.0-windows10.0.22621.0`, so it will require a recent Windows 11 SDK.

An attached CSV is provided in `lamparray.0.csv`. An image representation of this can be generated using
`plot.py` which requires the pillow library.

```console
pip install pillow
```

The resulting plot may look like this:
![example of a plot result](lamparray.0.png)