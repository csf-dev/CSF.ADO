//
// HasParametersAttribute.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2020 
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using AutoFixture;
using AutoFixture.NUnit3;
using Moq;

namespace CSF.Data.Tests
{
  public class HasParametersAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      return new HasParametersCustomization();
    }
  }

  public class HasParametersCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<IDbCommand>(c =>
      {
        return c
          .FromFactory(() => Mock.Of<IDbCommand>())
          .Do(command =>
          {
            Mock.Get(command)
              .Setup(x => x.CreateParameter())
              .Returns(() =>
              {
                var param = new Mock<IDbDataParameter>();
                param.SetupAllProperties();
                return param.Object;
              });

            var dbParams = Mock.Of<IDataParameterCollection>();
            Mock.Get(command).SetupGet(x => x.Parameters).Returns(dbParams);
          });
      });
    }
  }
}
