<script setup lang="ts">
import HomePage from './components/HomePage.vue';
import LegalContractsList  from "@/components/LegalContractsList.vue";
</script>

<template>
  <header>
    <nav>
      <ul>
        <li class="nav-item">
          <router-link to="/">Home</router-link>
        </li>
      </ul>
    </nav>
  </header>

  <main>
    <div class="wrapper">
      <HomePage msg="You did it!" />
    </div>
    
    <div class="wrapper">
      <LegalContractsList />
    </div>
  </main>
</template>

<style scoped>
  #app{
    font-family: Avenir, Helvetica, Arial, sans-serif;
  }
  
  header {
    line-height: 1.5;
  }
  
  .logo {
    display: block;
    margin: 0 auto 2rem;
  }
  
  @media (min-width: 1024px) {
    header {
      display: flex;
      place-items: center;
      padding-right: calc(var(--section-gap) / 2);
    }
    
    .nav-item {
      margin-right: 1rem;
    }
  
    header .wrapper {
      display: flex;
      place-items: flex-start;
      flex-wrap: wrap;
    }
  }
</style>
