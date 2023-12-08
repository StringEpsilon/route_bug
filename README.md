## How to reproduce:

1. Build this test application.
2. Click on the "Do with mode" link that is displayed by the "Do" view.
3. Observe redirect loop.

Note that the call to create the URL is identical in both `Do(string)` and `Do(string, Mode)`