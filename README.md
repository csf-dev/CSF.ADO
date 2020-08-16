# CSF.ADO
This very small repository contains two types of note:

*   `InMemoryDataReader` -  intended to be used as [a test fake] for `IDataReader`.  A developer initializes it with sample data (via its constructor) and it then behaves much like any other data-reader, as if that data were exposed by a database.
*   `DbCommandExtensions` - a tiny extension method for `IDbCommand` for the purpose of adding parameters.

Please note that this repository has been *renamed* from `CSF.Data`.  It also used to contain other functionality *which has since been moved* to the **[CSF.ORM]** repository.

[a test fake]: https://blog.pragmatists.com/test-doubles-fakes-mocks-and-stubs-1a7491dfa3da
[CSF.ORM]: https://github.com/csf-dev/CSF.ORM

## Open source license
All source files within this project are released as open source software,
under the terms of [the MIT license].

[the MIT license]: http://opensource.org/licenses/MIT

This software is distributed in the hope that it will be useful, but please
remember that:

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
