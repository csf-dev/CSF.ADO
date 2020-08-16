//
// TestIDbCommandExtensions.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2015 CSF Software Limited
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using NUnit.Framework;
using System.Data;
using Moq;

namespace CSF.ADO
{
  [TestFixture,Parallelizable]
  public class DbCommandExtensionsTests
  {
    [Test,AutoMoqData]
    public void AddParameter_adds_new_parameter_to_command_with_correct_values([HasParameters] IDbCommand command,
                                                                               string name,
                                                                               string val)
    {
      command.AddParameter(name, val);

      Mock.Get(command.Parameters)
        .Verify(x => x.Add(It.Is<IDbDataParameter>(p => p.ParameterName == name && (string) p.Value == val)), Times.Once);
    }

    [Test, AutoMoqData]
    public void AddParameter_uses_command_to_create_parameter([HasParameters] IDbCommand command,
                                                              string name,
                                                              string val)
    {
      command.AddParameter(name, val);

      Mock.Get(command).Verify(x => x.CreateParameter(), Times.Once);
    }
  }
}

