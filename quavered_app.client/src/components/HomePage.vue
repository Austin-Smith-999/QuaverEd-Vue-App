<template>
  <div class="d-flex align-items-center vh-100">
    <div class="mx-auto">
      <img alt="Q logo" src="./icons/Q_Icon.png" class="align-middle rotate" />
      <div class="fs-5 font-monospace text-center"> QuaverEd, Inc. </div>
    </div>
    <div v-if="post" class="content">
      <table>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="forecast in post" :key="forecast.date">
            <td>{{ forecast.date }}</td>
            <td>{{ forecast.temperatureC }}</td>
            <td>{{ forecast.temperatureF }}</td>
            <td>{{ forecast.summary }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<style>
 .rotate {
  animation: rotation 3s linear infinite;
}
  @keyframes rotation {
    from {
      transform: rotate3d(0, 1, 0, 0deg);
    }

    to {
      transform: rotate3d(0, 1, 0, 360deg);
    }
  }
</style>
<script lang="js">
  import { defineComponent } from 'vue';

  export default defineComponent({
    data() {
      return {
        loading: false,
        post: null
      };
    },
    created() {
      // fetch the data when the view is created and the data is
      // already being observed
      this.fetchData();
    },
    watch: {
      // call again the method if the route changes
      '$route': 'fetchData'
    },
    methods: {
      fetchData() {
        this.post = null;
        this.loading = true;

        fetch('Home')
          .then(r => r.json())
          .then(json => {
            this.post = json;
            this.loading = false;
            return;
          });
      }
    },
  });
</script>
