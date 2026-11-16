import hashlib
import json
import os
import sys

ARGS = [a for a in sys.argv[1:] if not a.startswith("--")]
ROOT = os.path.abspath(ARGS[0] if ARGS else ".")
SCOPES = ARGS[1:] or ["Farsi"]
PACKAGE = json.load(open(os.path.join(ROOT, "package.json")))["name"]
TAIL = "  externalObjects: {}\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n"
IMPORTERS = {
    ".cs": "MonoImporter:\n  externalObjects: {}\n  serializedVersion: 2\n  defaultReferences: []\n  executionOrder: 0\n  icon: {instanceID: 0}\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n",
    ".asmdef": "AssemblyDefinitionImporter:\n" + TAIL,
    ".json": "PackageManifestImporter:\n" + TAIL,
    ".md": "TextScriptImporter:\n" + TAIL,
}
FOLDER = "folderAsset: yes\nDefaultImporter:\n" + TAIL


def guid(relative):
    return hashlib.md5(f"{PACKAGE}/{relative}".encode()).hexdigest()


def meta(relative, body):
    return f"fileFormatVersion: 2\nguid: {guid(relative)}\n{body}"


def hidden(name):
    return name.startswith(".") or name.endswith("~")


def walk():
    for scope in SCOPES:
        base = os.path.join(ROOT, scope)
        if os.path.isdir(base):
            yield ROOT, [scope], []
            yield from os.walk(base)


def expected():
    result = {}
    for directory, folders, files in walk():
        folders[:] = sorted(f for f in folders if not hidden(f))
        for folder in folders:
            relative = os.path.relpath(os.path.join(directory, folder), ROOT)
            result[relative + ".meta"] = meta(relative, FOLDER)
        for name in sorted(files):
            extension = os.path.splitext(name)[1]
            if hidden(name) or extension not in IMPORTERS:
                continue
            relative = os.path.relpath(os.path.join(directory, name), ROOT)
            result[relative + ".meta"] = meta(relative, IMPORTERS[extension])
    return result


def main():
    check = "--check" in sys.argv
    wanted = expected()
    wrong = []
    for relative, content in wanted.items():
        path = os.path.join(ROOT, relative)
        current = open(path).read() if os.path.exists(path) else None
        if current != content:
            wrong.append(relative)
            if not check:
                with open(path, "w") as handle:
                    handle.write(content)
    for directory, folders, files in walk():
        folders[:] = [f for f in folders if not hidden(f)]
        for name in files:
            relative = os.path.relpath(os.path.join(directory, name), ROOT)
            if name.endswith(".meta") and relative not in wanted:
                wrong.append(relative)
                if not check:
                    os.remove(os.path.join(ROOT, relative))
    if check and wrong:
        print("meta files out of date:\n  " + "\n  ".join(sorted(wrong)))
        sys.exit(1)
    print(f"{len(wanted)} meta files {'checked' if check else 'written'}, {len(wrong)} {'wrong' if check else 'changed'}")


main()
