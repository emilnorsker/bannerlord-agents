# Gauntlet UI HTML Renderer

Parses Gauntlet XML prefabs and renders them as HTML matching in-game layout.

## Generate HTML

```bash
python3 scripts/gauntlet_xml_to_html.py ChatInterface -o scripts/chat-interface.html
python3 scripts/gauntlet_xml_to_html.py WorldEventsWindow -o scripts/world-events.html
```

## Serve

```bash
docker compose -f docker-compose.gauntlet-ui.yml up
```

Then open http://localhost:8080/chat-interface.html
