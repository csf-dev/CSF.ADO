A lot of the old functionality of this repository has been moved into **[CSF.ORM](https://github.com/csf-dev/CSF.ORM)**.  Further development on that work will be found there.

*It was found that a number of repositories were so closely linked that they should be converted to a single repository, even though they are multiple separate NuGet packages.*

---

# CSF.Data
These types assist in operating with data-sources.  Highlights are:

## InMemoryDataReader
This type is intended to be used as a test fake, when you wish to mock `IDataReader`.
It exposes a data-set which is passed into the constructor.

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
