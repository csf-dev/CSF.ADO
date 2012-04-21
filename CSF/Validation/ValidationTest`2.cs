//  
//  ValidationTest.cs
//  
//  Author:
//       Craig Fowler <craig@craigfowler.me.uk>
// 
//  Copyright (c) 2012 Craig Fowler
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Reflection;

namespace CSF.Validation
{
  /// <summary>
  /// Immutable specification type for a validation test, to be used with an <c>IValidator&lt;TTarget&gt;</c>
  /// </summary>
  public class ValidationTest<TTarget, TValue> : ValidationTest<TTarget>, IValidationTest<TTarget>
  {
    #region fields
    
    private ValidationFunction<TValue> _test;
    
    #endregion
    
    #region properties
    
    /// <summary>
    /// Gets the member associated with this test.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If this test is associated with a specific member then this will be non-null.  If the test is unassociated and
    /// is performed on the overall object instance then this property will return <c>null</c>.
    /// </para>
    /// <para>
    /// If this property is non-null then the <see cref="Test"/> function will be performed upon the value of the
    /// member.
    /// </para>
    /// </remarks>
    /// <value>
    /// The member.
    /// </value>
    public override MemberInfo Member
    {
      get {
        return base.Member;
      }
      protected set {
        if(value == null)
        {
          throw new ArgumentNullException ("value");
        }
        
        base.Member = value;
      }
    }
    
    /// <summary>
    /// Gets the test function that this instance performs.
    /// </summary>
    /// <value>
    /// The test function.
    /// </value>
    /// <exception cref='ArgumentNullException'>
    /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
    /// </exception>
    public new ValidationFunction<TValue> Test
    {
      get {
        return _test;
      }
      private set {
        if(value == null)
        {
          throw new ArgumentNullException ("value");
        }
        
        _test = value;
      }
    }
    
    #endregion
    
    #region methods
    
    /// <summary>
    /// Executes/performs this test against the specified target object instance.
    /// </summary>
    /// <param name='target'>
    /// The object instance to perform this test against.
    /// </param>
    public override bool Execute(TTarget target)
    {
      TValue testValue;
      
      if(target == null)
      {
        throw new ArgumentNullException ("target");
      }
      
      PropertyInfo property = this.Member as PropertyInfo;
      FieldInfo field = this.Member as FieldInfo;
      
      if(property != null)
      {
        testValue = (TValue) property.GetValue(target, null);
      }
      else if(field != null)
      {
        testValue = (TValue) field.GetValue(target);
      }
      else
      {
        throw new InvalidOperationException("Member must be either a PropertyInfo or a FieldInfo.");
      }
      
      return this.Test(testValue);
    }
    
    #endregion
    
    #region constructor
    
    /// <summary>
    /// Initializes a new validation test instance.
    /// </summary>
    /// <param name='test'>
    /// The test function that this instance performs.
    /// </param>
    /// <param name='member'>
    /// The member that this test is associated with.
    /// </param>
    /// <param name='identifier'>
    /// The identifier for this test, to distinguish it from other tests.
    /// </param>
    public ValidationTest(ValidationFunction<TValue> test,
                          MemberInfo member,
                          object identifier) : base(identifier, member)
    {
      this.Test = test;
    }
    
    #endregion
  }
}

