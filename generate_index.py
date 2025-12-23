import os
from datetime import datetime

TEMPLATE = """<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<title>Index of /{path}</title>
<style>
body {{ font-family: monospace; }}
table {{ border-collapse: collapse; }}
td {{ padding: 4px 12px; }}
</style>
</head>
<body>
<h1>Index of /{path}</h1>
<table>
<tr><th>Name</th><th>Last modified</th><th>Size</th></tr>
<tr><td><a href="../">../</a></td><td></td><td>-</td></tr>
{rows}
</table>
</body>
</html>
"""

def generate(dirpath):
    rows = []
    for name in sorted(os.listdir(dirpath)):
        if name.startswith('.') or name == 'index.html':
            continue
        full = os.path.join(dirpath, name)
        stat = os.stat(full)
        mod = datetime.fromtimestamp(stat.st_mtime).strftime("%Y-%m-%d %H:%M")
        if os.path.isdir(full):
            rows.append(f"<tr><td><a href='{name}/'>{name}/</a></td><td>{mod}</td><td>-</td></tr>")
        else:
            rows.append(f"<tr><td><a href='{name}'>{name}</a></td><td>{mod}</td><td>{stat.st_size}</td></tr>")
    return TEMPLATE.format(path=dirpath, rows="\n".join(rows))

for root, dirs, files in os.walk("."):
    if ".git" in root:
        continue
    with open(os.path.join(root, "index.html"), "w") as f:
        f.write(generate(root))
