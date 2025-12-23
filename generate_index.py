import os
from datetime import datetime

def gen(path):
    items = []
    for name in sorted(os.listdir(path)):
        if name.startswith('.'): continue
        p = os.path.join(path, name)
        stat = os.stat(p)
        items.append((name, stat))

    rows = ""
    for name, stat in items:
        size = "-" if os.path.isdir(os.path.join(path, name)) else f"{stat.st_size//1024}K"
        mod = datetime.fromtimestamp(stat.st_mtime).strftime("%Y-%m-%d %H:%M")
        slash = "/" if size == "-" else ""
        rows += f"<tr><td><a href='{name}{slash}'>{name}{slash}</a></td><td>{mod}</td><td>{size}</td></tr>"

    return f"""
    <html><body>
    <h1>Index of /{path}</h1>
    <table>{rows}</table>
    </body></html>
    """

for root, dirs, files in os.walk("data"):
    with open(os.path.join(root, "index.html"), "w") as f:
        f.write(gen(root))
