﻿using System.Linq;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using PseudoCQRS.PropertyValueProviders;
using Rhino.Mocks;

namespace PseudoCQRS.Tests.PropertyValueProviders
{
	[TestFixture]
	public class PropertyValueProviderFactoryTests
	{
		[SetUp]
		public void Setup()
		{
			var serviceLocator = MockRepository.GenerateMock<IServiceLocator>();
			ServiceLocator.SetLocatorProvider( () => serviceLocator );
		}

		[Test]
		public void ShouldReturnAllPropertyValueProviders()
		{
			var factory = new PropertyValueProviderFactory();
			Assert.AreEqual( 5, factory.GetPropertyValueProviders().Count() );
		}

		[Test]
		public void GetPersistablePropertyValueProviders_PersistanceLocationIsCookie_ReturnsCookiePersistablePropertyValueProvider()
		{
			var factory = new PropertyValueProviderFactory();
			Assert.IsInstanceOf<CookiePropertyValueProvider>( factory.GetPersistablePropertyValueProvider( PersistanceLocation.Cookie ) );
		}

		[Test]
		public void GetPersistablePropertyValueProvider_PersistanceLocationIsSession_ReturnsSessionPropertyValueProvider()
		{
			var factory = new PropertyValueProviderFactory();
			Assert.IsInstanceOf<SessionPropertyValueProvider>( factory.GetPersistablePropertyValueProvider( PersistanceLocation.Session ) );
		}
	}
}