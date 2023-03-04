const routes = [
    { path: '/',name:'Home', component: ()=> import('../views/Home.vue') },
    { path: '/product',name:'Product', component:()=> import('../views/product.vue') },
    { path: '/recommend',name:'Recommend', component:()=> import('../views/Recommend.vue') },
    { path: '/blog',name:'Blog', component:()=> import('../views/Blog.vue') },
    { path: '/checkout',name:'Checkout', component:()=> import('../views/Checkout.vue') },
    { path: '/account',name: 'Account', component:() => import('../views/Account.vue'),children: [
      {
        path: 'orders',
        component: () => import('../components/Orders.vue')
      }
    ]},

  ]
export default routes